# Araç Kiralama Uygulaması

## Proje Tanımı

Bu proje, bir araç kiralama firmasının personelleri için geliştirilmiş bir uygulamadır. Uygulama, araç kiralama işlemleri ve personel yönetimini veritabanı tabanlı bir sistemle sağlar. MVC yapısı ve katmanlı mimari kullanılarak geliştirilmiştir. Backend (API ve Service) ve frontend (MVC Controller ve View’ler) olarak iki ana katmana ayrılmıştır.

## İçindekiler

1. [Proje Yapısı ve Katmanlar](#proje-yapısı-ve-katmanlar)
2. [Kullanılan Kütüphaneler ve Yöntemler](#kullanılan-kütüphaneler-ve-yöntemler)
3. [Ana Sınıflar ve Yapılar](#ana-sınıflar-ve-yapılar)
4. [Kullanıcı Arayüzü ve Sayfalar](#kullanıcı-arayüzü-ve-sayfalar)
5. [Menü Yapısının Dinamik Oluşturulması](#menü-yapısının-dinamik-oluşturulması)
6. [Zorluklar ve Çözüm Yöntemleri](#zorluklar-ve-çözüm-yöntemleri)
7. [Sonuçlar ve Gelecek Çalışmalar](#sonuçlar-ve-gelecek-çalışmalar)

## Proje Yapısı ve Katmanlar

Proje, **Service**, **Core** ve **API** olmak üzere üç ana katmandan oluşmaktadır. Her bir katman belirli işlevleri yerine getirir ve bağımsız olarak geliştirilebilir ve test edilebilir.

- **Backend (API ve Service Katmanları)**: API katmanı dış dünya ile etkileşimi sağlarken, Service katmanı iş mantığını yönetir ve veri işleme işlemlerini gerçekleştirir.
  
- **Frontend (MVC Controller ve View’ler)**: Kullanıcı arayüzü, .NET MVC yapısı ile geliştirilmiştir. Kullanıcı etkileşimi için Controller'lar ve View'ler kullanılmıştır.

- **DB First Yaklaşımı**: Veritabanı yapısı, önceden oluşturulmuş ve DB First yaklaşımı ile Entity Framework Core üzerinden model sınıfları türetilmiştir. MSSQL veritabanı kullanılmıştır.

## Kullanılan Kütüphaneler ve Yöntemler

Proje kapsamında kullanılan ana kütüphaneler ve araçlar şunlardır:

- **.NET 8**: Projede kullanılan ana framework.
- **Entity Framework Core (DB First)**: Veritabanı işlemleri için kullanılan ORM.
- **ASP.NET Identity**: Kullanıcı yönetimi ve erişim kontrolü (kendi veritabanı sınıflarımızla yapılmıştır).
- **AutoMapper**: Veri transferi için kullanılan kütüphane.

## Ana Sınıflar ve Yapılar

Projede kullanılan bazı önemli sınıflar şunlardır:

- **BaseModel**: Tüm veritabanı modellerinin türediği temel sınıf.
- **MenuItem ve MenuItemRole**: Menü öğeleri ve bu öğelerin hangi roller tarafından erişilebileceğini belirleyen sınıflar.
- **Role ve UserRole**: Kullanıcı rollerini ve her bir kullanıcının sahip olduğu rollerin yönetildiği sınıflar.
- **User**: Kullanıcı bilgilerini tutan sınıf.
- **Vehicle**: Araç bilgilerini yöneten sınıf.
- **VehicleLog**: Araç kiralama ve iade işlemlerinin kayıtlarını tutan sınıf.

## Kullanıcı Arayüzü ve Sayfalar

Proje, kullanıcı dostu bir arayüzle geliştirilmiştir ve aşağıdaki sayfalardan oluşmaktadır:

- **Araç Yönetimi Sayfası**: Araçların eklenmesi, güncellenmesi ve silinmesi işlemleri.
- **Kiralama Yönetimi Sayfası**: Araç kiralama işlemlerinin yönetimi.

## Menü Yapısının Dinamik Oluşturulması

Proje, dinamik bir menü yapısı kullanır. Menü öğeleri, veritabanından dinamik olarak okunur ve kullanıcıya uygun şekilde sunulur. Menü, bir **component** olarak tasarlanmış ve **MenuItem** ve **MenuItemRole** sınıflarıyla yönetilmiştir.

### Dinamik Partial View’ler

Araç yönetimi ve kiralama işlemleri gibi ekranlar, dinamik olarak **PartialView** kullanılarak oluşturulmuştur. Bu sayede kullanıcılar, sayfa yenilenmeden veri güncelleyebilir ve işlemlerini hızlıca gerçekleştirebilirler.

## Zorluklar ve Çözüm Yöntemleri

Proje boyunca karşılaşılan bazı zorluklar ve çözüm yöntemleri:

- **Erişim Kontrolü**: Kullanıcı yönetimi ve erişim kontrolü için kendi veritabanı sınıflarımızla işlem yapılmıştır. Bu, esneklik ve özelleştirme sağlamıştır.
- **Dinamik Menü Yapısı**: Menü öğelerinin dinamik şekilde yönetilmesi ve kullanıcıların erişimine sunulması, başlangıçta karmaşık olsa da doğru sınıf yapıları ile çözülmüştür.

## Sonuçlar ve Gelecek Çalışmalar

Proje başarıyla tamamlanmıştır ve tüm temel işlevler (araç kiralama, araç yönetimi, kullanıcı yönetimi) düzgün şekilde çalışmaktadır. Gelecekte yapılabilecek iyileştirmeler şunlar olabilir:

- Kullanıcı deneyimini artıracak yeni özellikler eklemek.
- Performans iyileştirmeleri yapmak.
- Daha kapsamlı raporlama özellikleri eklemek.

---
