:: Copy Selenium Build

SET "src_root=\\<BuildServerLocationPath>"
set "tgt_path=E:automationSE"

DIR %src_root% /B /AD /O-D /TC > "%TEMP%\dirlist.tmp"
< "%TEMP%\dirlist.tmp" SET /P last_dir=

XCOPY "%src_root%\%last_dir%\*" "%tgt_path%" /S /E /Y