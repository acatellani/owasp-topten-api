$Certname = "CursoOwaspCert"
# Define expiration
$YearsToExpire = 1
Write-Host "Creating Certifcate $Certname" -ForegroundColor Green
# Create certificate
$Cert = New-SelfSignedCertificate -CertStoreLocation "Cert:\LocalMachine\My" -dnsname $Certname -NotAfter (Get-Date).AddYears($YearsToExpire)
Write-Host "Exporting Certificate $Certname to .\$Certname.pfx" -ForegroundColor Green
# Set password to export certificate
$pw = ConvertTo-SecureString -String "123456" -Force -AsPlainText
# Get thumbprint
$thumbprint = $Cert.Thumbprint
Write-Host "Thumbprint: " $thumbprint
$fullPath = "Cert:\LocalMachine\My\" + $thumbprint 
Write-Host $fullPath
# Export certificate
Export-PfxCertificate -Cert $fullPath -FilePath .\$Certname.pfx -Password $pw
