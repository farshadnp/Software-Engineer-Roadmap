import json
from pathlib import Path

p = Path('progress.json')
d = json.loads(p.read_text(encoding='utf-8'))
d['plan_version'] = 2
d['updated_at'] = '2026-09-06'
d['start_date'] = '2026-09-06'
d['learner']['learning_mode'] = 'Concept-first book mentoring; interactive code review and why explanations; occasional learner coding'
d['automation'] = {'id':'automation','status':'ACTIVE','daily_time':'19:00','intended_timezone':'Asia/Tehran','weekly_review_day':'Friday','stop_review_date':'2026-11-01'}
d['open_questions'] = [q for q in d['open_questions'] if 'ساعت احتمالی' not in q]
s = d['sessions'][0]
s['title'] = 'API and responsibility boundaries; conversational baseline'
s['reference'] = 'Chapter 3, sections 3.1.1-3.1.2; PDF pages 76-77'
s['acceptance'] = 'Explain HTTP-specific behavior versus shared application rules; review a small example. Environment and practical baseline are deferred until the first executable exercise.'
s['status'] = 'studying'
s['taught_topics'] = ['Intro: API contract and HTTP versus application rules']
s['pending_question'] = 'Which parts of the note endpoint should also apply to a CSV import, and which are HTTP-specific?'
s['lesson_path'] = 'lessons/W1D1.md'
s['actual_minutes'] = None
p.write_text(json.dumps(d,ensure_ascii=False,indent=2)+'\n',encoding='utf-8')
with Path('SESSION-LOG.md').open('a',encoding='utf-8') as f:
    f.write('\n## ۲۰۲۶-۰۹-۰۶ — تغییر روش و آغاز W1D1\n\nترجیح کاربر: مفاهیم کتاب، کدریویو، سؤال‌وجواب و چرایی؛ گاهی کدنویسی. نسخه ۲ برنامه ثبت شد. پیگیری روزانه ۱۹:۰۰ و مرور جمعه فعال شد (automation). درس آغازین از فصل ۳ و یک نمونه آموزشی مستقل آماده و ارائه شد: API و جداسازی HTTP از قانون ایجاد Note. منتظر پاسخ سؤال import از CSV هستیم. هیچ پاسخ، اجرای عملی یا تسلط تأیید نشده؛ زمان کاربر نامعلوم. قدم بعد بررسی پاسخ و نمایش تغییر قبل/بعد است.\n')
assert len(d['sessions']) == 48
assert sum(s['status']=='verified' for s in d['sessions']) == 0
assert Path(s['lesson_path']).exists()
print('Updated mentor preferences and first lesson; 0 verified sessions; learner response pending.')
