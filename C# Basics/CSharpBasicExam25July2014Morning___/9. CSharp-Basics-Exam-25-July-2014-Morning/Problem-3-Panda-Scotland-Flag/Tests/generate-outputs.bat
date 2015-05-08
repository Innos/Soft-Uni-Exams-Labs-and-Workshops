FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    flag.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
