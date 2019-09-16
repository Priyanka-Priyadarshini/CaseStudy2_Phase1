//=============================================================================
  COPYRIGHT KONINKLIJKE PHILIPS ELECTRONICS N.V. 2019<br/>
  All rights are reserved. Reproduction in whole or in part is
  prohibited without the written consent of the copyright owner.
//============================================================================= 
 
# PatientMonitorSystemCaseStudy2
An API to serve multiple clients.<br/>
BedCongifuration API- BedConfigurationController -> This configures the patient beds and discharge of patient.<br/>
Patient Monitoring API-1)PatientMonitoringController -> This enables the patient vitals and generates random data for it. <br/>
                       2)PatientVitalsStorageController -> This is used to store the patient data in memory.<br/>
                       3)PatientAlertController -> It validates the patient vitals and provides alert.<br/>
## Installation
### Clone
Clone this repo to your local machine using https://github.com/Priyanka-Priyadarshini/CaseStudy2_Phase1.git<br/>
API documentation will be available here :<br/>
1)BedConfigurationService- http://localhost:58905/swagger/index.html<br/>
2)PatientMonitoringService- http://localhost:1080/swagger/index.html<br/>
Run the AutoBuildTest.bat file to execute the application.<br/>
### Code Metrics
Maximum cyclomatic complexity per function: 3<br/>
Code coverage: The report has been attached.<br/>
Code Duplication details available in the batch file. Please update the path of your simian.exe in the batch file.
