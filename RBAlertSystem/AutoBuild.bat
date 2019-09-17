@echo off
set "BAT_PATH=%~dp0"



@echo off


call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsDevCmd.bat"

echo %BAT_PATH%

echo Executing batch file

:: param1 =     certificate hash for cash microservice : default no certificate

:: param2 =     Build Type: default Debug, Range: Debug or Release
::Win32
::              
:: To Make it to work open BranchConfiguration.json then set the value of "name": "BranchProfile" 

::              to as per Build Type like, "value": "Release" or "value": "Debug", By default the vlaue is debug
::X64

::              To Make it to work open BranchConfiguration64.json then set the value of "name": "BranchProfile" 

::              to as per Build Type like, "value": "Release" or "value": "Debug", By default the vlaue is debug

:: param3 =     Infra Compiling: default: build, Range: nobuild OR build
:: param4 =     Platform: default: x64 or Win32, Range: Win32 OR x64

devenv "%BAT_PATH%\RBAlertSystem.sln" /build Debug 
pause


set testPath=%BAT_PATH%TemperatueValidatorLib.Tests\bin\Debug\TemperatueValidatorLib.Tests.dll
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath=%BAT_PATH%SPO2ValidatorLib.Tests\bin\Debug\SPO2ValidatorLib.Tests.dll
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath=%BAT_PATH%PulseRateValidatorLib.Tests\bin\Debug\PulseRateValidatorLib.Tests.dll
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath=%BAT_PATH%PatientVitalsDataGeneratorLib.Tests\bin\Debug\PatientVitalsDataGeneratorLib.Tests.dll
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx


set testPath=%BAT_PATH%EnablePatientVitalsLib.Tests\bin\Debug\EnablePatientVitalsLib.Tests.dll
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath=%BAT_PATH%DataAccessLib.Tests\bin\Debug\DataAccessLib.Tests.dll
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath=%BAT_PATH%RuleBasedPatientVitalsAlertUponValidationLib.Tests\bin\Debug\RuleBasedPatientVitalsAlertUponValidationLib.Tests.dll
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx

set testPath=%BAT_PATH%QueuePatientVitalsStorageLib.Tests\bin\Debug\QueuePatientVitalsStorageLib.Tests.dll
vstest.console.exe %testPath% /ResultsDirectory:./TestResults /InIsolation /logger:trx



mstest /TestContainer:"%BAT_PATH%TemperatueValidatorLib.Tests\bin\Debug\TemperatueValidatorLib.Tests.dll" /Test:GivenTemperatureValue96_WhenValidateCalled_ThenExpectedFalse /Test:GivenTemperatureValue97_WhenValidateCalled_ThenExpectedTrue /Test:GivenTemperatureValue99_WhenValidateCalled_ThenExpectedTrue /Test:GivenTemperatureValue100_WhenValidateCalled_ThenExpectedFalse

mstest /TestContainer:"%BAT_PATH%SPO2ValidatorLib.Tests\bin\Debug\SPO2ValidatorLib.Tests.dll" /Test:GivenSpo2Value90_WhenValidateCalled_ThenExpectedFalse /Test:GivenSpo2Value90_WhenValidateCalled_ThenExpectedFalse /Test:GivenSpo2Value91_WhenValidateCalled_ThenExpectedTrue /Test:GivenSpo2Value95_WhenValidateCalled_ThenExpectedTrue /Test:GivenSpo2Value96_WhenValidateCalled_ThenExpectedFalse

mstest /TestContainer:"%BAT_PATH%PulseRateValidatorLib.Tests\bin\Debug\PulseRateValidatorLib.Tests.dll" /Test:GivenPulseRateValue59_WhenValidateCalled_ThenExpectedFalse /Test:GivenPulseRateValue60_WhenValidateCalled_ThenExpectedTrue /Test:GivenPulseRateValue100_WhenValidateCalled_ThenExpectedTrue /Test:GivenPulseRateValue101_WhenValidateCalled_ThenExpectedFalse

mstest /TestContainer:"%BAT_PATH%PatientVitalsDataGeneratorLib.Tests\bin\Debug\PatientVitalsDataGeneratorLib.Tests.dll" /Test:GivenPatientId_WhenGeneratePatientVitals_ExpectedPatientVitalsObject /Test:GivenPatientIdNull_WhenGeneratePatientVitals_ExpectedException

mstest /TestContainer:"%BAT_PATH%EnablePatientVitalsLib.Tests\bin\Debug\EnablePatientVitalsLib.Tests.dll" /Test:GivenListOfPatientVitals_WhenEnablePatientVitalsCalled_ThenExpectedCountOne /Test:GivenNullPatientVitalsList_WhenEnablePatientVitalsCalled_ThenExceptionExpected /Test:GivenSamePatientIdTwice_WhenEnablePatientVitalsCalled_ThenExpectedCountOne /Test:GivenPatientIdNull_WhenEnablePatientVitalsCalled_ThenExpectedCountOne

mstest /TestContainer:"%BAT_PATH%DataAccessLib.Tests\bin\Debug\DataAccessLib.Tests.dll" /Test:GivenPatientVitals_WhenWritePatientVitalsDataCalled_ExpectedGlobalCountOne /Test:GivenDifferentPatientId_WhenWritePatientVitalsDataCalled_ExpectedGlobalCountTwice
/Test:GivenPatientIdIsStored_WhenReadPatientVitalsDataCalled_ThenExpectedPatientVitalsData /Test:GivenPatientIdNotStoredBefore_WhenReadPatientVitalsDataCalled_ThenExpectedNull /Test:GivenEnabledPatientVitalsListForPatientId_WhenWriteListOfEnabledPatientVitals_ThenExpectedGlobalCountOne /Test:GivenDifferentListForExistingPatientIdWithEnabledPatientVitals_WhenWriteListOfEnabledPatientVitals_ThenExpectedGlobalCountOne
/Test:GivenTwoPatientIdsWithEnabledVitalsList_WhenWriteListOfEnabledPatientVitals_ThenExpectedGlobalCountTwo

mstest /TestContainer:"%BAT_PATH%RuleBasedPatientVitalsAlertUponValidationLib.Tests\bin\Debug\RuleBasedPatientVitalsAlertUponValidationLib.Tests.dll" /Test:GivenPatientIdWhoseDataStored_WhenPatientVitalsAlertUponValidation_ThenExpectedAlertMessage /Test:GivenPatientIdWhoseDataStored_WhenPatientVitalsAlertUponValidation_ThenExpectedHealthy
/Test:GivenPatientIdDoesntExist_WhenPatientVitalsAlertUponValidation_ThenExpectedException /Test:GivenPatientIdIsNull_WhenPatientVitalsAlertUponValidation_ThenExpectedException

mstest /TestContainer:"%BAT_PATH%QueuePatientVitalsStorageLib.Tests\bin\Debug\QueuePatientVitalsStorageLib.Tests.dll" /Test:GivenPatientIdIsNull_WhenStorePatientVitalsDataCalled_ExpectedException /Test:GivenPatientVitals_WhenStorePatientVitalsDataCalled_ExpectedMokerFunctionCalledOnce
/Test:GivenSamePatientIdTwice_WhenStorePatientVitalsDataCalled_ExpectedMokerFunctionCalledTwice


pause

set "SIM_PATH=C:\Users\320066905\Simian\bin\"

cd "%SIM_PATH%"

simian-2.5.10.exe "%BAT_PATH%\**\*.cs"{threshold=6}  

pause

start "" http://localhost:59372/api/values


pause

