# نگاشت کتاب به برنامه

منبع: Mastering ASP.NET Core 10، Mabrouk Mahdhi، Apress، ©۲۰۲۵، ISBN الکترونیکی 979-8-8688-1892-9. فایل ارائه‌شده ۸۹۱ صفحه PDF دارد. شماره چاپی از فهرست و شماره PDF از bookmark همان فایل استخراج شده‌اند؛ اختلاف آن‌ها ثابت نیست. «شروع PDF» شمارش یک‌مبنا در نمایشگر است.

| فصل | عنوان | شروع چاپی | شروع PDF | اولویت | هفته |
|---|---|---:|---:|---|---|
| 1 | Welcome to ASP.NET Core 10 | 3 | 44 | مرور | ۱ |
| 2 | Setting Up Your Dev Environment | 13 | 53 | اصلی | ۱ |
| 3 | Creating Your First ASP.NET Core 10 Application | 35 | 75 | اصلی | ۱ |
| 4 | Understanding the ASP.NET Core 10 Pipeline | 65 | 105 | اصلی | ۱ |
| 5 | The .NET Ecosystem: Core, Framework, and Beyond | 85 | 125 | مرور | ۱ |
| 6 | Mastering Dependency Injection | 111 | 150 | اصلی | ۱ |
| 7 | Routing and Endpoints in ASP.NET Core 10 | 125 | 164 | اصلی | ۲ |
| 8 | Configuration and Options in ASP.NET Core 10 | 145 | 183 | اصلی | ۱ |
| 9 | Logging and Monitoring | 169 | 206 | اصلی | ۶ |
| 10 | Building Secure Applications | 181 | 218 | اصلی | ۴ |
| 11 | Integrating Databases with EF Core | 215 | 252 | اصلی | ۳ |
| 12 | Building Efficient APIs with ASP.NET Core | 245 | 282 | اصلی؛ OData اختیاری | ۲–۴ |
| 13 | SignalR and Real-Time Communication | 307 | 344 | اختیاری / بعد از مسیر | — |
| 14 | Caching and Performance Optimization | 331 | 367 | انتخابی مرتبط با پروژه | ۶ |
| 15 | File Handling and Storage | 369 | 404 | انتخابی؛ آپلود/دانلود امن | ۴ |
| 16 | Razor Pages: Simplified Web Development | 427 | 460 | بعد از مسیر بک‌اند | — |
| 17 | Model Binding and Validation | 467 | 499 | منتخب مرتبط با API | ۲ |
| 18 | Advanced MVC Patterns | 503 | 534 | فقط modularization؛ بقیه بعداً | ۵ |
| 19 | Blazor Server: A Modern Approach to Web Apps | 537 | 567 | بعد از مسیر بک‌اند | — |
| 20 | Blazor WebAssembly: Full-Stack Web Development | 581 | 610 | بعد از مسیر بک‌اند | — |
| 21 | Using Tag Helpers and View Components | 613 | 641 | بعد از مسیر بک‌اند | — |
| 22 | Building Rich Forms with Tag Helpers | 637 | 664 | بعد از مسیر بک‌اند | — |
| 23 | Integrating .NET MAUI with ASP.Net Core | 651 | 678 | بعد از مسیر بک‌اند | — |
| 24 | Building Hybrid Applications with Blazor and .NET MAUI | 669 | 696 | بعد از مسیر بک‌اند | — |
| 25 | Unit Testing and Integration Testing | 683 | 709 | اصلی؛ UI testing اختیاری | ۱،۲،۳،۷ |
| 26 | Optimizing Performance in ASP.NET Core 10 | 703 | 729 | اصلی منتخب | ۶ |
| 27 | Deploying ASP.NET Core Applications | 721 | 746 | اصلی؛ یک هدف استقرار کافی | ۷ |
| 28 | Extending ASP.NET Core with Middleware | 733 | 757 | منتخب | ۶ |
| 29 | Creating the Final Project: Planning and Setup | 747 | 771 | مرجع دامنه و معماری در طول مسیر | ۱،۳،۵،۸ |
| 30 | Building the Final Project | 783 | 807 | ۲–۴،۷ و۸ منتخب؛ UI اختیاری | ۳–۸ |

فصل‌های اصلی هم به صورت هدف‌محور خوانده می‌شوند، نه الزاماً تمام مثال‌ها خط‌به‌خط. مبحثی که به بعد موکول شده در optional_backlog باقی می‌ماند و انجام‌شده حساب نمی‌شود.

## بخش‌های پروژه نهایی برای مراجعه سریع

| موضوع | بخش | شروع PDF |
|---|---|---:|
| مسئله و نیازمندی‌ها | ۲۹.۲ | ۷۷۳ |
| معماری The Standard | ۲۹.۳ | ۷۷۸ |
| مدل Note/Tag/Attachment | ۲۹.۶ | ۷۹۴ |
| لایه داده | ۳۰.۲ | ۸۱۰ |
| قوانین و سرویس‌ها | ۳۰.۳ | ۸۱۶ |
| Controllerها | ۳۰.۴ | ۸۲۵ |
| دغدغه‌های مشترک | ۳۰.۷ | ۸۴۲ |
| تست | ۳۰.۸ | ۸۴۷ |

مقدمه در صفحه PDF ۴۱، آشنایی قبلی با C# را پیش‌فرض می‌داند. پیاده‌سازی نمونه کتاب از SQLite و Blazor استفاده می‌کند و authentication در معرفی پروژه اختیاری است؛ اجباری‌شدن مالکیت و API محور شدن پروژه، تصمیم این برنامه برای هدف بک‌اند است. معماری کتاب را بررسی و نقد می‌کنیم؛ نام The Standard به معنای استاندارد اجباری صنعت یا فریم‌ورک نیست.

