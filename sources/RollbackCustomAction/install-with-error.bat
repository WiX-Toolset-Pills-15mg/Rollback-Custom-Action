:: ====================================================================================================
:: Step 5: Install with error and rollback
:: ====================================================================================================
::
:: Run the installer and look into the "install-with-error.log" file.
:: 
:: NEXT: install-with-success.bat

msiexec /i RollbackCustomAction.msi /l*vx install-with-error.log WIXFAILWHENDEFERRED=1