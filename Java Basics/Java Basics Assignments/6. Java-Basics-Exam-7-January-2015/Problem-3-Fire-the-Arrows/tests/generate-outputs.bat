javac *.java
FOR %%f in ("*.in.txt") DO (
	SETLOCAL EnableDelayedExpansion
    SET "file=%%f"
    java P02_Move_the_Arrows < "%%f" > "!file:.in.txt=.out.txt!"
)
PAUSE
