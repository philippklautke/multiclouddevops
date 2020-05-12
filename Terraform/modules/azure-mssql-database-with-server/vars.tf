variable "sqlResourceGroupName" {
    description = "Name of the Azure Resource Group to create"
}
variable "sqlServerName" {
    description = "Name of the SQL Server"
}
variable "sqlServerAdminName" {
    description = "Sql Server Admin User Name"
}
variable "sqlServerAdminPassword" {
    description = "Sql Server Admin User Password"
}
variable "sqlDatabaseName" {
    description = "Name of the Database"
}
variable "azure_location" {
    description = "Location of the Azure Resources"
}
variable "azure_subscriptionId" {
    description = "Subscription Id of Azure Subscription"
}
variable "azure_clientId" {
    description = "Service Principal Client Id for Azure Management"
}
variable "azure_clientSecret" {
    description = "Service Principal Client Secret for Azure Management"
}
variable "azure_tenant" {
    description = "Tenant Id for Azure Tenant"
}
provider "azurerm" {
    version = "=2.0.0"
    subscription_id = var.azure_subscriptionId
    client_id = var.azure_clientId
    client_secret = var.azure_clientSecret
    tenant_id = var.azure_tenant
    features {}
}