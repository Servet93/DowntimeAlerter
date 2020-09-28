# DowntimeAlerter / Invicti Security Health Monitoring

Çok kullanıcılı, girilen uygulamaların çalışır durumda olup olmadığını kontrol eder.

## Kullanılanlar

### Net Core MVC 3.1
### Entity Framework 3.1.8
### HangFire 1.7.14
### MailKit,MimeKit 2.9.2
### NLog 4.7.5

## Kurulum

1.Projeden Migrations dizinini silin.

![GitHub Logo](https://i.ibb.co/L0Q74Lz/1-migrationsil.png)

2.Projede yer alan appsetting.json dosyasında veritabanı bağlantı ayarınızı yapın.
```
 "ConnectionStrings": {
        "InvictiHealtMonitoringConnection": "Server=(localdb)\\mssqllocaldb;Database=InvictiHealthMonitoring;Trusted_Connection=True;MultipleActiveResultSets=true",
        "InvictiBackgroundJobsConnection": "Server=(localdb)\\mssqllocaldb;Database=InvictiBackgroundJobs;Trusted_Connection=True;MultipleActiveResultSets=true"
    },
```
3.Migrationları oluşturmak için PackageManagerda veya komut satırında aşağıdaki komutu çalıştırın.
```
dotnet ef migrations add "init" --project WebUI --output-dir Infrastructure\Migrations
```

4.Oluşan model ve datanın verabanına yansıması için aşağıdaki komutu çalıştırın.
```
dotnet ef database update --project WebUI
```

5.Oluşması gereken database ve tablolar.
![GitHub Logo](https://i.ibb.co/54Njqgc/Invicti-Health-Monitoring.png)
![GitHub Logo](https://i.ibb.co/16C3F01/Invicti-Health-Background-Jobs.png)

6.Gönderici mail ayarlarını appsettings.json dosyasında tanımlayın.
```
"MailSettings": {
        "Mail": "invictisec@gmail.com",
        "DisplayName": "Servet ŞEKER  / Invicti Security Corp",
        "Password": ".Ss123456",
        "Host": "smtp.gmail.com",
        "Port": 587
    },
```

## Kullanıcı Bilgileri

Admin
Email : invicti@security.com
Pw : .Ii123456

Normal
Email : servetseker@security.com
Pw : .Ss123456

Email : serkanseker@security.com
Pw : .Ss654321

## Ekran Görüntüleri

![GitHub Logo](https://i.ibb.co/FDkgd1p/1-Home-Not-Login.png)

![GitHub Logo](https://i.ibb.co/4KcGsBZ/2-Home-Not-Login-Query-Success.png)

![GitHub Logo](https://i.ibb.co/7g50vqR/3-Home-Not-Login-Query-No-Success.png)

![GitHub Logo](https://i.ibb.co/MMQ4VHn/4-Home-Sign-In.png)

![GitHub Logo](https://i.ibb.co/fF3718S/5-Home-Create-App.png)

![GitHub Logo](https://i.ibb.co/sbj7JP5/6-Home-Table.png)

![GitHub Logo](https://i.ibb.co/6mbQ2g0/7-Table-Deleted.png)

![GitHub Logo](https://i.ibb.co/3d45fRJ/9-Table-Update.png)

![GitHub Logo](https://i.ibb.co/c8FGf82/10-Table-Updated.png)

![GitHub Logo](https://i.ibb.co/FKWZzC7/12-App-Running.png)

![GitHub Logo](https://i.ibb.co/vxTGk85/12-App-Running-1.png)

![GitHub Logo](https://i.ibb.co/mHHthMh/13-App-Running-2.png)

![GitHub Logo](https://i.ibb.co/mh1HBNQ/14-App-Stop.png)

![GitHub Logo](https://i.ibb.co/wQHJLB5/15-App-Stopped.png)

![GitHub Logo](https://i.ibb.co/wQHJLB5/15-App-Stopped.png)

![GitHub Logo](https://i.ibb.co/qBrTzW9/17-Fail-Request.png)

![GitHub Logo](https://i.ibb.co/DLFcGpj/17-Mail.png)
