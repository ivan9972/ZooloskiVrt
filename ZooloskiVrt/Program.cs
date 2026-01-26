using Microsoft.EntityFrameworkCore;
using ZooloskiVrt;
using ZooloskiVrt.Data;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// DbContext
builder.Services.AddDbContext<ZooloskiVrtContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZooloskiVrtCS"))
);

var app = builder.Build();

// Migracije + Seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ZooloskiVrtContext>();

    // napravi/primijeni migracije
    db.Database.Migrate();

    // seed samo ako nema osnovnih podataka
    if (!db.Radnici.Any() && !db.Nastambe.Any() && !db.Zivotinje.Any())
    {
        SeedData.Initialize(db);
    }
}

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Zivotinja}/{action=Index}/{id?}"
);

app.Run();
