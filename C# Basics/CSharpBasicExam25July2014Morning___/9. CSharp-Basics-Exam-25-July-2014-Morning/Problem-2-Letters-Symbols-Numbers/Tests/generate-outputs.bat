FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    letters.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
