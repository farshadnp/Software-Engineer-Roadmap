# دفتر جلسات

## گزارش پایان روز دوم — ۲۰۲۶-۰۹-۰۸

- W1D1 از نظر مفهومی پوشش داده شد و در وضعیت `awaiting_review` است: مرز API/Service/Entity/Repository، invariant، exception mapping، تست Entity و persistence، ChangeTracker و generated values. امتیاز فعلی: توضیح ۲، پیاده‌سازی/رفع ایراد ۱، trade-off برابر ۲، verification عملی هنوز ارزیابی نشده.
- W1D2 عملاً شروع شده است: Task/await، ترتیب continuation، انتشار exception، try/catch/finally، انتقال CancellationToken، retry و idempotency مقدماتی. ارزیابی کامل آن هنوز انجام نشده است.
- شاهد mentor: آزمایش EF Core generated values اجرا شد؛ این اجرای mentor است و مهارت عملی یادگیرنده محسوب نمی‌شود.
- پیشرفت تأییدشده سخت‌گیرانه: ۰ از ۴۸ جلسه verified و ۰ از ۸ gate. پیشرفت محتوایی: یک جلسه مفهومی پوشش داده شده و جلسه دوم آغاز شده است. بحث فرعی ABP طبق درخواست از مسیر ادامه حذف شد.
- قدم بعد: تکمیل async/await با یک code review کوچک، سپس nullable و LINQ/IQueryable؛ برای بستن W1D1 یک اجرای عملی تست‌های Note لازم است.

## ادامه W1D2 — ۲۰۲۶-۰۹-۰۹

- در review اجرای concurrent با دو DbContext، یادگیرنده درست تشخیص داد عملیات ساخت Tag ممکن است پیش از ذخیره/commit شدن Note اجرا شود و Note مرجع را پیدا نکند. تکمیل: هر context transaction مستقل دارد؛ Task.WhenAll اتمیک‌بودن نمی‌دهد، پس Note می‌تواند commit و Tag fail شود و partial state باقی بماند. برای یک aggregate در یک دیتابیس، افزودن هر دو entity به یک scoped DbContext و یک SaveChanges معمولاً مرز transaction مناسب‌تری است؛ EF ترتیب INSERTها را با توجه به relationship تنظیم می‌کند.
- در مرور nullable، whitespace دوباره با null اشتباه شد: `"   ".Trim()` رشته خالی می‌دهد و exception ایجاد نمی‌کند؛ اگر title واقعاً null باشد، نخستین دسترسی `title.Length` یک NullReferenceException می‌دهد. موضوع null/empty/whitespace برای مرور مجدد علامت‌گذاری شد. nullable annotation قرارداد و هشدار تحلیل ایستا است و به‌تنهایی runtime guard نیست.

## آماده‌سازی برنامه — ۲۰۲۶-۰۹-۰۶

درخواست: آمادگی حداقل Mid-level، تمرکز بک‌اند و معماری، ۳ ساعت مفید روزانه و توانایی کنترل کیفیت Agentها.

اقدام انجام‌شده: بررسی فهرست ۳۰ فصل، مقدمه و بخش‌های منتخب پروژه NoteKeeper؛ ساخت برنامه ۸ هفته‌ای و دفتر پیشرفت. این اقدام جلسه آموزشی محسوب نمی‌شود.

مطالب تدریس/ارزیابی‌شده به یادگیرنده: هنوز هیچ جلسه اجرا نشده است. پیشرفت: ۰/۴۸ جلسه؛ ۰/۸ gate. قدم بعدی: W1D1 و BASELINE.md. تاریخ شروع هنوز ثبت نشده است.

## قالب ثبت جلسه بعد

- تاریخ و شناسه جلسه:
- زمان واقعی و میزان کمک Agent:
- بخش‌های واقعاً مطالعه‌شده (گزارش کاربر):
- مطالب توضیح‌داده‌شده در جلسه:
- تمرین و شاهد (مسیر فایل/commit/خروجی تست):
- اشتباهات یا نکات نامطمئن:
- امتیاز توضیح، اجرا/رفع باگ، تست، دفاع از تصمیم:
- وضعیت، دلیل آن و موعد مرور:
- قدم بعد و مانع احتمالی:

### ادامه کدریویو پاسخ خطا

- یادگیرنده یک پاسخ امن با status 503، پیام عمومی و traceId ساخت. status برای unavailable موقت درست است و اطلاعات فنی افشا نشده. اصلاحات review: پیام از اصطلاح داخلی Backoffice مستقل و کوتاه باشد؛ traceId مقدار واقعی request correlation است و الزاماً GUID نیست. همچنین 503 فقط برای unavailable موقت تشخیص‌داده‌شده است؛ database failure ناشناخته معمولاً 500 است.
- یادگیرنده outage شناخته‌شده و موقت را 503 و failure ناشناخته را 500 انتخاب کرد؛ هر دو درست. دقت اضافه: صرف شناخته‌شدن علت برای 503 کافی نیست؛ failure باید واقعاً بیانگر unavailable بودن موقت سرویس یا dependency باشد. ارزیابی فعلی W1D1: توضیح مفاهیم در سناریوی آشنا سطح ۲، trade-off سطح ۲، تمرین کدنویسی با اصلاحات نحوی سطح ۱، و verification عملی هنوز ارزیابی نشده است.
- در review طراحی Active Record مانند، یادگیرنده پیش از داوری توضیح دقیق اجرای `SaveAsync` و معنای `this` را درخواست کرد. نکات تدریس: constructor dependency از بیرون می‌گیرد؛ `SaveAsync` متد instance روی Entity است، ورودی صریح ندارد؛ `this` همان نمونه جاری Note است؛ `DbSet.Add(this)` آن نمونه و graph قابل دسترس را Added/tracked می‌کند؛ `SaveChangesAsync` همه تغییرات tracked همان DbContext را flush می‌کند و فقط محدود به this نیست. سپس coupling و testability بررسی می‌شوند.
- یادگیرنده طراحی Entity دارای AppDbContext را رد کرد و پیشنهاد داد CRUD در Repository قرار گیرد و Service فقط با Repository کار کند؛ دلیل‌های درست: جداسازی persistence و کاهش تکرار ترجمه خطا. تکمیل mentor: نمونه قبلی Entity بود نه Service؛ Repository/Broker abstraction باید هدفمند باشد چون EF Core DbContext خودش رفتار Repository/Unit of Work دارد؛ provider exception در مرز persistence ترجمه می‌شود، اما تصمیم business conflict ممکن است به context سرویس نیاز داشته باشد. درباره unit test پاسخ نداشت؛ توضیح داده می‌شود که تست invariant نباید نیازمند ساخت provider/options/context، mock نامرتبط یا null نامعتبر باشد و Entity وابسته به EF قابل استفاده و آزمون مستقل نیست.
- یادگیرنده درباره `private Note() { }` پرسید. توضیح لازم: parameterless constructor خصوصی مسیر ساخت برای EF Core materialization است و جلوی `new Note()` در کد مصرف‌کننده را می‌گیرد؛ مسیر عمومی باید factory/constructor معتبر باشد. EF Core می‌تواند constructor غیرعمومی را استفاده و property/fieldها را materialize کند. این constructor همیشه اجبار مطلق نیست چون EF Core constructor binding نیز دارد. برای nullable property باید مقداردهی EF و هشدار کامپایل با دقت مدیریت شود؛ `null!` فقط هشدار را suppress می‌کند و invariant runtime نمی‌سازد.
- یادگیرنده مسیر عمومی `new Note()` را درست تحلیل کرد: Create/NormalizeTitle دور زده می‌شود و Title نامعتبر می‌ماند. اصلاح شد که Guid غیرnullable مقدار پیش‌فرض `Guid.Empty` دارد، نه null. سپس AAA معرفی شد و یادگیرنده unit test صحیحی برای whitespace نوشت که `NoteValidationException` را با `Assert.Throws` بررسی می‌کند. نام تست می‌تواند دقیق‌تر `WhitespaceTitle` باشد؛ Act و Assert در الگوی exception عمداً در `Assert.Throws` ترکیب‌اند. مرحله بعد استفاده از `[Theory]` برای null/empty/whitespace است؛ اجرای واقعی تست هنوز ثبت نشده است.
- در بازیابی constructor، یادگیرنده درست تشخیص داد `new Note()` مسیر factory و invariant را دور می‌زند و Title در runtime null می‌ماند. اصلاح شد که Guid غیرnullable به‌طور پیش‌فرض `Guid.Empty` است، نه null. در AAA testing، Arrange را ایجاد ورودی/شرایط، Act را اجرای رفتار و Assert را بررسی نتیجه دانست. نکته تکمیلی: در `Assert.Throws(() => Note.Create(title))`، lambda حاوی Act است و خود `Assert.Throws` assertion؛ در تست trim نمونه فعلی Arrange و Act را با literal و فراخوانی در یک خط فشرده کرده بود.
- در سؤال بازیابی، یادگیرنده درست تشخیص داد که عمومی‌کردن constructor اجازه `new Note()` می‌دهد و مسیر Create/NormalizeTitle و invariant دور زده می‌شود؛ همچنین استفاده تست از factory معتبر را ضمنی توضیح داد. اصلاح C#: `Title` در runtime null است، اما `Guid` چون value type غیرnullable است null نمی‌شود و مقدار پیش‌فرضش `Guid.Empty` است؛ فقط `Guid?` می‌تواند null باشد.

### تست مثبت و خروجی observable

- یادگیرنده درست تشخیص داد که `" My note "` باید پذیرفته شود و Title نهایی `"My note"` باشد. به‌جای assertion صرف بر رخ ندادن exception، خروجی observable یعنی مقدار نرمال‌شده بررسی می‌شود. قدم بعد boundary tests برای طول ۹۹، ۱۰۰ و ۱۰۱ پس از Trim است؛ اجرای تست در محیط هنوز مشاهده نشده است.
- در boundary testing، یادگیرنده درست نتیجه گرفت طول‌های نرمال‌شده ۹۹ و ۱۰۰ معتبر، ۱۰۱ نامعتبر، و ورودی padded با طول نهایی ۱۰۰ معتبر است. این نشان می‌دهد شرط `> 100` و ترتیب Trim سپس length check را فهمیده است. قدم بعد تمایز unit test موجودیت از integration test persistence است.
- در تمایز integration test، یادگیرنده درست گفت تست Repository جریان ذخیره و بازیابی، اتصال و ناسازگاری احتمالی schema/migration را آشکار می‌کند. محدودیت‌ها: این فقط اتصال/config دیتابیس تست را اثبات می‌کند، نه production؛ migration drift فقط وقتی سنجیده می‌شود که test DB با migrationهای واقعی provision شود، نه صرفاً EnsureCreated. برای اثبات round-trip بهتر است write و read با DbContextهای جدا انجام شود تا ChangeTracker همان نمونه نتیجه را پنهان نکند.

### ChangeTracker و استقلال context

- یادگیرنده درست توضیح داد context دوم از ChangeTracker اول بی‌اطلاع است و بازیابی آن شاهد قوی‌تری برای persistence واقعی است. سؤال تکمیلی کاربر: آیا می‌توان از ابتدا AsNoTracking را برای ذخیره و سپس خواندن با همان context استفاده کرد؟ پاسخ: AsNoTracking فقط رفتار query/materialization را تنظیم می‌کند و روی Add/Save اعمال نمی‌شود. پس از Save می‌توان query را AsNoTracking کرد یا tracker را با Clear/Detached پاک کرد؛ این‌ها round-trip بهتری می‌سازند، اما context جدید lifecycle مستقل و جلوگیری بهتر از state یا transaction مشترک را نشان می‌دهد.

### Async/await و cancellation

- یادگیرنده ترتیب try/catch/finally را در success و DbUpdateException درست پیش‌بینی کرد. اصلاح شد که await exception را catch نمی‌کند، بلکه آن را در نقطه await propagate می‌کند؛ continuation فقط پس از موفقیت اجرا می‌شود. درباره CancellationToken نیز درست گفت اگر Service token نگیرد، کار متوقف نمی‌شود. نکته تکمیلی: cancellation مشارکتی است؛ token باید تا I/O منتقل و توسط عملیات مشاهده شود و توقف/rollback فوری تضمین نیست. در writeها قطع client می‌تواند نتیجه نامعلوم برای client بسازد و idempotency اهمیت پیدا می‌کند.
- در سناریوی retry پس از commit و گم‌شدن پاسخ، یادگیرنده احتمال duplicate را درست تشخیص داد. دقت اضافه: مشکل اصلی duplicate effect/business operation است؛ اگر هر retry شناسه جدید بسازد و constraint تجاری وجود نداشته باشد، هر دو row ذخیره می‌شوند و exception رخ نمی‌دهد. Idempotency-Key با unique constraint و ثبت نتیجه باید تشخیص retry را ممکن کند.

## ۲۰۲۶-۰۹-۰۶ - تغییر روش و آغاز W1D1

ترجیح کاربر: مفاهیم کتاب، کدریویو، سؤال‌وجواب و چرایی؛ گاهی کدنویسی. نسخه ۲ برنامه ثبت شد. پیگیری روزانه ۱۹:۰۰ و مرور جمعه فعال شد (automation). درس آغازین از فصل ۳ و یک نمونه آموزشی مستقل آماده و ارائه شد: API و جداسازی HTTP از قانون ایجاد Note. منتظر پاسخ سؤال import از CSV هستیم. هیچ پاسخ، اجرای عملی یا تسلط تأیید نشده؛ زمان کاربر نامعلوم. قدم بعد بررسی پاسخ و نمایش تغییر قبل/بعد است.

### پاسخ‌های کدریویو W1D1

- یادگیرنده تشخیص داد که مسیر CSV باید داده را parse و به ورودی عملیات افزودن Note تبدیل کند و نرمال‌سازی عنوان را مطرح کرد.
- در سناریوی عنوان نامعتبر، ابتدا whitespace را با null یکسان در نظر گرفت؛ روشن شد که `Trim()` فقط برای null استثنا می‌دهد و رشته خالی/فقط فاصله بدون exception به رشته خالی تبدیل می‌شود. همچنین شکست یک request الزاماً کل ASP.NET Core process را متوقف نمی‌کند.
- درباره مرز مسئولیت گفت سرویس باید ورودی نامعتبر را متوقف کند. جهت جریان نیاز به اصلاح داشت: ورودی HTTP ابتدا به endpoint می‌رسد، سپس سرویس فراخوانی می‌شود. نتیجه درست در حال تثبیت است: سرویس invariant را اعمال و شکست مستقل از HTTP را اعلام می‌کند؛ endpoint آن را به پاسخ HTTP نگاشت می‌کند.
- وضعیت جلسه همچنان `studying` است؛ پاسخ بعدی باید مشخص کند چرا Service نباید مستقیماً `BadRequest` برگرداند و مسیر CSV همان شکست را چگونه دریافت می‌کند.
- یادگیرنده مطرح کرد که validation در API و CSV importer می‌تواند تکراری باشد و مسئولیت سرویس‌ها را زیاد کند. نکته آموزشی بعدی: تفکیک validation نحوی و مخصوص ورودی در boundary از invariant برنامه در NoteService؛ تکرار invariant در همه ورودی‌ها خطر دور زدن و ناسازگاری دارد. بررسی قانون Note در Service افزایش ناموجه مسئولیت نیست، چون مسئولیت این Service اجرای معتبر عملیات Note است.
- یادگیرنده محل مناسب قانون خالی نبودن عنوان را خود موجودیت Note دانست، چون رفتار پایه آن است. این پاسخ از دید domain modeling درست و قابل دفاع است. نکته بعدی: صرف افزودن یک متد کافی نیست؛ تمام مسیرهای ایجاد و تغییر باید invariant را حفظ کنند و setter عمومی نباید راه دور زدن بسازد. نقش Service پس از آن orchestration، policyهای وابسته به repository/user/time و ترجمه شکست دامنه به failure سطح application است.
- در review متد `Rename`، یادگیرنده ایراد اصلی «ورودی نامعتبر» را درست تشخیص داد. برای کامل‌شدن review باید حالات null، empty و whitespace را از هم جدا کند و اصلاح را به helper مشترک Create/Rename متصل کند تا invariant در همه مسیرها یکسان بماند.
- یادگیرنده تمرین `NormalizeTitle` را انجام داد: ترتیب whitespace check، Trim و length check درست بود. خطاهای C# اصلاح شدند: `Length` property است، exception با `new` ساخته می‌شود، و پس از throw نیازی به else نیست. در طبقه‌بندی exception نیز درست تشخیص داد که exception سفارشی امکان تمایز validation را می‌دهد و برای database exceptionهای تخصصی وجود دارند. نکته بعدی: تمایز failure مورد انتظار دامنه از failure فنی، wrap کردن در مرز dependency، حفظ InnerException برای log و ندادن جزئیات فنی به client.
- در تمرین نگاشت HTTP، یادگیرنده validation را درست 400 انتخاب کرد و duplicate/database unavailable را به‌ترتیب 400 و 500 دانست. اصلاح آموزشی: duplicate شناخته‌شده که با وضعیت فعلی منبع تعارض دارد معمولاً 409 است؛ unavailable موقت dependency معمولاً 503 و قابل retry است. 500 برای شکست داخلی غیرمنتظره باقی می‌ماند. unique constraint ناشناخته نباید صرفاً با دیدن DbUpdateException به 409 تبدیل شود؛ constraint باید قابل شناسایی و به conflict سطح application نگاشت شود.
- یادگیرنده ایراد catch عمومی `DbUpdateException -> NoteConflictException` را درست تشخیص داد: update ممکن است به دلایل مختلف شکست بخورد و این نگاشت علت اصلی را mask می‌کند. اصطلاح دقیق‌تر از mute کردن، masking/misclassification است. قدم بعد: catch اختصاصی برای unique constraint، حفظ exception اصلی به‌عنوان InnerException، و نگاشت سایر DbUpdateExceptionها به dependency failure.
- یادگیرنده دلیل ندادن InnerException به client را درست توضیح داد: client باید خطای کنترل‌شده و validation قابل اقدام ببیند و جزئیات exception می‌تواند اطلاعات داخلی غیرضروری را افشا کند. تکمیل آموزشی: پاسخ امن هنوز باید نوع شکست قابل اقدام (۴۰۰/۴۰۹/۵۰۳)، پیام عمومی و traceId داشته باشد؛ stack trace، schema/path/provider و داده حساس فقط در log کنترل‌شده باقی می‌مانند. جداسازی همچنین قرارداد API را از EF/provider مستقل نگه می‌دارد.
- صورت تمرین ProblemDetails برای یادگیرنده مبهم بود. روشن شد که تمرین فعلاً فقط تکمیل یک JSON پاسخ است، نه نوشتن C#. سه فیلد: status برای نوع HTTP، title برای پیام عمومی امن، و traceId برای تطبیق پاسخ client با log سرور.
- در تمرین HTTP mapping، یادگیرنده هر سه حالت را ابتدا 400 دانست. اصلاح شد: عنوان خالی 400؛ تعارض unique قابل بیان در قرارداد معمولاً 409؛ عدم دسترسی موقت دیتابیس 503. باید در ادامه تفاوت مسئولیت client در 400/409 با امکان retry در 503 تثبیت شود و یادآوری شود که constraint ناشناخته نباید کورکورانه به 409 تبدیل شود.
- تمرین کدنویسی `NormalizeTitle`: ترتیب منطقی صحیح بود (رد null/whitespace، سپس Trim، سپس سنجش سقف ۱۰۰). ایرادهای C#: طول رشته property به نام `Length` است نه `length()`؛ پرتاب exception نیازمند `throw new ...` است؛ `else` پس از throw زائد است. لازم است exception مشخص دامنه با پیام/اطلاعات مناسب استفاده شود. اجرای کامپایل هنوز مشاهده نشده است.
