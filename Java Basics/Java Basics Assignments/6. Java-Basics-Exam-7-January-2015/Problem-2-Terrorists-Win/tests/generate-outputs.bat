javac *.java
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java P02_Terrorists_Win < "%%f" > "!file:.in.txt=.out.txt!"
)
PAUSE
