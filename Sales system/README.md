### Execute Database 
dotnet ef dbcontext scaffold "Server=127.0.0.1;Database=salesSystem;Username=postgres;Password=123456789" Npgsql.EntityFrameworkCore.PostgreSQL -o Models -f
 