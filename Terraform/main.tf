module "aws_s3_bucket_static_website" {
    source = "./modules/aws-s3-static-website"
    bucket_name = var.site_name
    aws_access_key = var.aws_access_key
    aws_secret_key = var.aws_secret_key
    aws_region = var.aws_region
}

module "azure_appservice" {
    source = "./modules/azure-webapp-with-plan"
    app_settings = {
        "Testappsetting" = "testappsetting"
    }
    appName = var.appName
    azure_location = var.azure_location
    azure_subscriptionId = var.azure_subscriptionId
    azure_clientId = var.azure_clientId
    azure_clientSecret = var.azure_clientSecret
    azure_tenant = var.azure_tenant
}

module "azure_sql" {
    source = "./modules/azure-mssql-database-with-server"
    sqlResourceGroupName = "${var.appName}dbrg"
    sqlServerName = "${var.appName}dbserver"
    sqlServerAdminName = var.azure_dbadmin
    sqlServerAdminPassword = var.azure_dbadminpassword
    sqlDatabaseName = "${var.appName}-db"
    azure_location = var.azure_location
    azure_subscriptionId = var.azure_subscriptionId
    azure_clientId = var.azure_clientId
    azure_clientSecret = var.azure_clientSecret
    azure_tenant = var.azure_tenant
}
terraform {
    backend "azurerm" {
        resource_group_name = var.azure_terraformStateStorageResourceGroup
        storage_account_name = var.azure_terraformStateStorageAccountName
        container_name = var.azure_terraformStateStorageContainerName
        key = "terraform.tfstate"
    }
}
