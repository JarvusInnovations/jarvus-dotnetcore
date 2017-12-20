<#

As of Nov 26, 2017, this script is installed in Azure's automation service to scale dev purposed
databases down to Standard S0 price tiers at midnight EST.

#>

$DatabaseNames = @("JeffersonsList-JSmiley2", "JeffersonsList-QA", "JeffersonsList-Staging")
$ResourceGroup = "JL"
$DatabaseServer = "devserver3"

$Conn = Get-AutomationConnection -Name AzureRunAsConnection
Add-AzureRMAccount -ServicePrincipal -Tenant $Conn.TenantID `
    -ApplicationId $Conn.ApplicationID -CertificateThumbprint $Conn.CertificateThumbprint

foreach ($dbName in $DatabaseNames) {
    Write-Host "scaling down database"
    Write-Debug "debug scaling down db"
    # Scale the database performance to Standard S1
    $database = Set-AzureRmSqlDatabase -ResourceGroupName $ResourceGroup `
        -ServerName $DatabaseServer `
        -DatabaseName $dbName `
        -Edition "Standard" `
        -RequestedServiceObjectiveName "S0"
}