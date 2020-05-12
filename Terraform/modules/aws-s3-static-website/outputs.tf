output "website_endpoint" {
    description = "Domain Name of the Bucket"
    value = aws_s3_bucket.bucket.website_endpoint
}