output "app_defaulturl" {
    description = "Domain Name of the Website"
    value = azurerm_app_service.webapp.default_site_hostname
}