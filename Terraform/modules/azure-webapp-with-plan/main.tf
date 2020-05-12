resource "azurerm_resource_group" "webapp" {
    name = "${var.appName}-group"    
    location = var.azure_location
}
resource "azurerm_app_service_plan" "webapp" {
    name = "${var.appName}-backend"
    location = azurerm_resource_group.webapp.location
    resource_group_name = azurerm_resource_group.webapp.name   
    kind = "Windows"
    reserved = true
    sku {
        tier = "Standard"
        size ="S1"
    }
}
resource "azurerm_app_service" "webapp" {
    name = "${var.appName}-app"
    location = azurerm_resource_group.webapp.location
    resource_group_name = azurerm_resource_group.webapp.name
    app_service_plan_id = azurerm_app_service_plan.webapp.id
    app_settings = var.app_settings
}