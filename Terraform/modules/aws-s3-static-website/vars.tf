variable "bucket_name" {
    description = "Name of the Bucket"
}
variable "aws_access_key" {
    description = "AWS Access Key"
}
variable "aws_secret_key" {
    description = "AWS Secret Key"
}
variable "aws_region" {
    description = "AWS Region"
}

provider "aws" {
    access_key = var.aws_access_key
    secret_key = var.aws_secret_key
    region = var.aws_region
    version = "=2.61.0"    
}
