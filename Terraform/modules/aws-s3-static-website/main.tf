resource "aws_s3_bucket" "bucket" {
    bucket = var.bucket_name
    website {
        index_document = "index.html"
    }    
}

resource "aws_s3_bucket_policy" "bucket" {
    bucket = aws_s3_bucket.bucket.id    
    policy = <<POLICY
{
    "Version": "2008-10-17",
    "Id": "PolicyForPublicWebsiteContent",
    "Statement": [
        {
            "Sid": "PublicReadGetObject",
            "Effect": "Allow",
            "Principal": {
                "AWS": "*"
            },
            "Action": "s3:GetObject",
            "Resource": "arn:aws:s3:::${var.bucket_name}/*"
        }
    ]
}
POLICY
}