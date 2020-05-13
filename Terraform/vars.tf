variable "aws_region" {
    description = "AWS deployment region"
}
variable "aws_access_key" {
    description = "AWS Access Key"
}
variable "aws_secret_key" {
    description = "AWS Secret Key"
}
variable "site_name" {
    description = "Name of the Bucket"
}
variable "azure_subscriptionId" {
    description = "Subscription Id of Azure Subscription"
}
variable "azure_location" {
    description = "Region of Azure Resources"
}
variable "appName" {
    description = "App Name of the Web App"
}
variable "azure_clientId" {
    description = "Client ID to Connect with"
}
variable "azure_clientSecret" {
    description = "Client Secret to Connect with"
}
variable "azure_tenant" {
    description = "Tenant Id to connect to"
}
variable "azure_dbadmin" {
    description = "DBAdmin User Name"
}
variable "azure_dbadminpassword" {
    description = "DB Admin User Password"
}
variable "azure_terraformStateStorageResourceGroup" {
    description = "Resource Group of the Storage Account for State Management"
}
variable "azure_terraformStateStorageAccountName" {
    description = "Storage Account Name of the Storage Account for State Management"
}
variable "azure_terraformStateStorageContainerName" {
    description = "Container Name within Storage Account for State Management"
}
