# Midtrans.Payment
Your Project Description Here..

## Migration Data
Run "Database.sql" di sql server untuk membuat database dan generate table

## Use Code Generator
### 1.Install tool
klik kanan di project Midtrans.Payment.Data kemudian pilih open in terminal kemudian ketik :
```powershell
dotnet tool install --global dotnet-ef 
atau
dotnet tool update --global dotnet-ef
```
### 2.Scaffolding 
setelah mengeksekusi install tool kemudian ketik/copy code berikut :
```scaffold
dotnet ef dbcontext scaffold "Data Source=mediaindoteknologi.com,5031;Initial Catalog=Homeplate;User Id=sa;Password=antapani@1b" Microsoft.EntityFrameworkCore.SqlServer --output-dir "..\Midtrans.Payment.Data\Model" -c ApplicationDBContext --context-dir "..\Midtrans.Payment.Data" --namespace "Midtrans.Payment.Data.Model" --context-namespace "Midtrans.Payment.Data" --no-pluralize -f --no-onconfiguring --schema "dbo"
```
ganti localhost username dan password apabila ingin merubah koneksi ke server yang dituju.

### 3.Generated file
show all files di project Midtrans.Payment.Data maka akan terbentuk file *generated" dan didalamnya terdapat backend dan frontend disana tinggal copy paste saja kedalam core untuk kebutuhan table.

## Use DAL
untuk cara pemakain bisa dibaca di [Vleko.DAL](https://github.com/Vlekops/DAL)


