# Generate Service Broker Metadata from JSON template.

Examines the parameters of the JSON Cloudformation template to create the Service Broker Metadata for the template in JSON and YAML format. 
It will include all parameters in the template into the metadata.

## Setup

1. Requires .net core 2.1 (https://dotnet.microsoft.com/download/dotnet-core/2.1) (for Windows/MacOS/Linux/Other)
2. No build process required
3. Run the application's DLL from command line (found in .\bin\Release\netcoreapp2.1\ServiceBrokerMetaGen.dll) : 
```
dotnet \ServiceBrokerMetaGen\bin\Release\netcoreapp2.1\ServiceBrokerMetaGen.dll
```
4. Provide the requested template in JSON format. 
5. Outputs the AWS::ServiceBroker::Specification in both JSON and YAML format. 
6. Copy and Paste ithe ouput into your template under the MetaData section.
7. Edit the output to remove parameters not needed within a service plan.

## Demo Output

```

C:\Test>dotnet ServiceBrokerMetaGen.dll
Create ServiceBroker MetaData for template
==========================================

Enter in path to JSON template:
C:\aws-servicebroker\templates\rdsmssql\template.json

==================================JSON========================================

{
  "AWS::ServiceBroker::Specification": {
    "Version": "1",
    "Tags": [
      "",
      ""
    ],
    "Name": "",
    "DisplayName": "",
    "LongDescription": "",
    "ImageUrl": "",
    "DocumentationUrl": "",
    "ProviderDisplayName": "Amazon Web Services",
    "ServicePlans": {
      "production": {
        "DisplayName": "Production",
        "Description": "Configuration designed for production deployments",
        "LongDescription": "",
        "Cost": "",
        "ParameterValues": {
          "AccessCidr": null,
          "AllocatedStorageAndIops": "100GB 1000IOPS",
          "AllowMajorVersionUpgrade": "false",
          "AutoMinorVersionUpgrade": "true",
          "AvailabilityZones": "Auto",
          "BackupRetentionPeriod": "35",
          "CidrBlocks": "Auto",
          "CopyTagsToSnapshot": "true",
          "DBInstanceClass": "db.m5.large",
          "SqlEdition": "sqlserver-se",
          "EngineVersion": "SQL-Server-2017-14.00.3049.1.v1",
          "MasterUserPassword": "Auto",
          "MasterUsername": "Master",
          "MonitoringInterval": "1",
          "MultiAZ": "false",
          "ServerTimezone": "UTC",
          "NumberOfAvailabilityZones": "2",
          "CidrSize": "27",
          "PortNumber": "1433",
          "PreferredBackupWindow": "00:00-02:00",
          "PreferredMaintenanceWindowDay": "Mon",
          "PreferredMaintenanceWindowEndTime": "06:00",
          "PreferredMaintenanceWindowStartTime": "04:00",
          "PubliclyAccessible": "false",
          "StorageEncrypted": "false",
          "StorageType": "io1",
          "VpcId": null
        }
      },
      "dev": {
        "DisplayName": "Development",
        "Description": "Configuration designed for development and testing deployments",
        "LongDescription": "",
        "Cost": "",
        "ParameterValues": {
          "AccessCidr": null,
          "AllocatedStorageAndIops": "100GB 1000IOPS",
          "AllowMajorVersionUpgrade": "false",
          "AutoMinorVersionUpgrade": "true",
          "AvailabilityZones": "Auto",
          "BackupRetentionPeriod": "35",
          "CidrBlocks": "Auto",
          "CopyTagsToSnapshot": "true",
          "DBInstanceClass": "db.m5.large",
          "SqlEdition": "sqlserver-se",
          "EngineVersion": "SQL-Server-2017-14.00.3049.1.v1",
          "MasterUserPassword": "Auto",
          "MasterUsername": "Master",
          "MonitoringInterval": "1",
          "MultiAZ": "false",
          "ServerTimezone": "UTC",
          "NumberOfAvailabilityZones": "2",
          "CidrSize": "27",
          "PortNumber": "1433",
          "PreferredBackupWindow": "00:00-02:00",
          "PreferredMaintenanceWindowDay": "Mon",
          "PreferredMaintenanceWindowEndTime": "06:00",
          "PreferredMaintenanceWindowStartTime": "04:00",
          "PubliclyAccessible": "false",
          "StorageEncrypted": "false",
          "StorageType": "io1",
          "VpcId": null
        }
      },
      "custom": {
        "DisplayName": "Custom",
        "Description": "Custom Configuration for Advanced deployments",
        "LongDescription": "",
        "Cost": "",
        "ParameterValues": {}
      }
    }
  }
}

==================================YAML========================================

AWS::ServiceBroker::Specification:
  Version: 1
  Tags:
  - ''
  - ''
  Name: ''
  DisplayName: ''
  LongDescription: ''
  ImageUrl: ''
  DocumentationUrl: ''
  ProviderDisplayName: Amazon Web Services
  ServicePlans:
    production:
      DisplayName: Production
      Description: Configuration designed for production deployments
      LongDescription: ''
      Cost: ''
      ParameterValues: &o0
        AccessCidr:
        AllocatedStorageAndIops: 100GB 1000IOPS
        AllowMajorVersionUpgrade: false
        AutoMinorVersionUpgrade: true
        AvailabilityZones: Auto
        BackupRetentionPeriod: 35
        CidrBlocks: Auto
        CopyTagsToSnapshot: true
        DBInstanceClass: db.m5.large
        SqlEdition: sqlserver-se
        EngineVersion: SQL-Server-2017-14.00.3049.1.v1
        MasterUserPassword: Auto
        MasterUsername: Master
        MonitoringInterval: 1
        MultiAZ: false
        ServerTimezone: UTC
        NumberOfAvailabilityZones: 2
        CidrSize: 27
        PortNumber: 1433
        PreferredBackupWindow: 00:00-02:00
        PreferredMaintenanceWindowDay: Mon
        PreferredMaintenanceWindowEndTime: 06:00
        PreferredMaintenanceWindowStartTime: 04:00
        PubliclyAccessible: false
        StorageEncrypted: false
        StorageType: io1
        VpcId:
    dev:
      DisplayName: Development
      Description: Configuration designed for development and testing deployments
      LongDescription: ''
      Cost: ''
      ParameterValues: {}
    custom:
      DisplayName: Custom
      Description: Custom Configuration for Advanced deployments
      LongDescription: ''
      Cost: ''
      ParameterValues: {}


==================================END=========================================
```
