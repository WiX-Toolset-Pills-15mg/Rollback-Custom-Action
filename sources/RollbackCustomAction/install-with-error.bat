:: ====================================================================================================
:: Step 4a: Install with error and rollback
:: ====================================================================================================
::
:: Run the installer and look into the "install-with-error.log" file.
:: 
:: NEXT: install-with-success.bat

msiexec /i RollbackCustomAction.msi /l*vx install-with-error.log ERROR_MESSAGE="Crush Boom Bang"