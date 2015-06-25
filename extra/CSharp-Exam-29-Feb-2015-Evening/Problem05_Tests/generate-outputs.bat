csc *.cs
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    HorsePath.exe < "%%f" > "!file:.in.txt=.out.txt!"
)
del *.exe
