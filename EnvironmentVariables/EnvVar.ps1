$valorVariable = [Environment]::GetEnvironmentVariable("ConnetionString","User")

Write-Host $valorVariable

if ([string]::IsNullOrEmpty($valorVariable)) {
	Write-Host "Variable no existente, creando"
	[Environment]::SetEnvironmentVariable("ConnetionString", "CSTest", "User")
} else {
	Write-Host "La variable ya existe"
}