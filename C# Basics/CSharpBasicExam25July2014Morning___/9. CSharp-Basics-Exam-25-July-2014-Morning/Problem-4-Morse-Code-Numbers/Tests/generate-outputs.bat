FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    morse.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
