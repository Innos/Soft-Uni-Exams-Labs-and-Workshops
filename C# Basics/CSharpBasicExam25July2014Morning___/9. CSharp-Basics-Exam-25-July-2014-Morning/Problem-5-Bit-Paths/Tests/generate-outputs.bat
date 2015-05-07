FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    bitpaths.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
