#!/usr/bin/env python3
"""
Merge many CSV files into one, keeping the header only once.

Usage:
  python merge_csvs.py --input-dir "/path/to/csvs" --output "merged.csv" [--pattern "*.csv"] [--encoding "utf-8"] [--newline]
"""

import argparse
import csv
import glob
import os
import sys

def main():
    parser = argparse.ArgumentParser(description="Merge many CSV files into one, keeping only the first header.")
    parser.add_argument("--input-dir", required=True, help="Folder that contains the CSV files.")
    parser.add_argument("--output", required=True, help="Path for the merged CSV file to create.")
    parser.add_argument("--pattern", default="*.csv", help="Glob pattern to match CSV files (default: *.csv).")
    parser.add_argument("--encoding", default="utf-8", help="File encoding (default: utf-8). Use 'utf-8-sig' if BOM present, or 'cp1252' on some Windows exports.")
    parser.add_argument("--dialect", default=None, help="Optional csv dialect name to use (e.g., excel, excel-tab). If omitted, auto-sniff is used per file.")
    parser.add_argument("--newline", action="store_true",
                        help="If set, writes CRLF newlines (Windows style). Default uses platform default.")
    parser.add_argument("--sort", choices=["name", "mtime"], default="name",
                        help="Order to merge files: by filename (name) or modified time (mtime). Default: name")
    args = parser.parse_args()

    input_dir = os.path.abspath(args.input_dir)
    output_path = os.path.abspath(args.output)
    newline_arg = "" if not args.newline else "\r\n"

    # Collect files
    pattern_path = os.path.join(input_dir, args.pattern)
    files = glob.glob(pattern_path)
    if not files:
        print(f"No files found matching {pattern_path}", file=sys.stderr)
        sys.exit(1)

    # Sort files deterministically
    if args.sort == "name":
        files.sort(key=lambda p: os.path.basename(p).lower())
    else:
        files.sort(key=lambda p: os.path.getmtime(p))

    # Prevent output file from being read as input if paths overlap
    files = [f for f in files if os.path.abspath(f) != output_path]

    print(f"Found {len(files)} file(s). Merging into: {output_path}")

    header_written = False
    expected_header = None
    total_rows = 0

    # Ensure output directory exists
    os.makedirs(os.path.dirname(output_path) or ".", exist_ok=True)

    # Open output once; write incrementally
    with open(output_path, "w", newline="" if not args.newline else "", encoding=args.encoding) as out_f:
        writer = None

        for idx, file_path in enumerate(files, start=1):
            try:
                with open(file_path, "r", newline="", encoding=args.encoding, errors="replace") as in_f:
                    # Dialect detection per file if not forced
                    if args.dialect:
                        dialect = args.dialect
                        reader = csv.reader(in_f, dialect=dialect)
                    else:
                        # Sniff first 4096 bytes to detect delimiter/quotechar
                        sample = in_f.read(4096)
                        in_f.seek(0)
                        try:
                            sniffed = csv.Sniffer().sniff(sample)
                            reader = csv.reader(in_f, dialect=sniffed)
                        except csv.Error:
                            # Fallback: default excel dialect
                            reader = csv.reader(in_f)

                    try:
                        header = next(reader)
                    except StopIteration:
                        print(f"[WARN] {os.path.basename(file_path)} is empty; skipping.")
                        continue

                    # Initialize writer with the header from first non-empty file
                    if not header_written:
                        writer = csv.writer(out_f, lineterminator="\n" if not args.newline else "\r\n")
                        writer.writerow(header)
                        header_written = True
                        expected_header = header
                        print(f"[INFO] Using header from: {os.path.basename(file_path)}")
                    else:
                        # Validate headers match
                        if header != expected_header:
                            print(f"[WARN] Header mismatch in {os.path.basename(file_path)}. "
                                  f"Continuing, but columns may misalign.")

                    # Stream the rest of the rows
                    row_count_this_file = 0
                    for row in reader:
                        writer.writerow(row)
                        total_rows += 1
                        row_count_this_file += 1

                    print(f"[OK]  {idx}/{len(files)}: {os.path.basename(file_path)} → {row_count_this_file} data rows")

            except Exception as ex:
                print(f"[ERROR] Failed processing {file_path}: {ex}", file=sys.stderr)

    print(f"\nDone. Wrote {total_rows} total data rows (excluding header) to {output_path}")

if __name__ == "__main__":
    main()