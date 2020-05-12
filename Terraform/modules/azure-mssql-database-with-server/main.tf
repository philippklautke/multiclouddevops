resource "azurerm_resource_group" "sql" {
    name = var.sqlResourceGroupName
    location = var.azure_location
}
resource "azurerm_sql_server" "sql" {
    name = var.sqlServerName
    resource_group_name = azurerm_resource_group.sql.name
    location = azurerm_resource_group.sql.location
    version = "12.0"
    administrator_login = var.sqlServerAdminName
    administrator_login_password = var.sqlServerAdminPassword
}
resource "azurerm_sql_firewall_rule" "sql" {
    name ="AllowAzureServices"
    resource_group_name = azurerm_resource_group.sql.name
    server_name = azurerm_sql_server.sql.name
    start_ip_address = "0.0.0.0"
    end_ip_address = "0.0.0.0"
}
resource "azurerm_sql_database" "sql" {
    name = var.sqlDatabaseName
    resource_group_name = azurerm_resource_group.sql.name
    location = azurerm_resource_group.sql.location
    server_name = azurerm_sql_server.sql.name
    edition = "Basic"
    requested_service_objective_name = "Basic"
}