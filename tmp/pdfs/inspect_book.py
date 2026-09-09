from pathlib import Path
from pypdf import PdfReader
import importlib.util

source = Path(r'C:\Users\f.nematpur\Desktop\Mastering ASP.NET Core 10.pdf')
reader = PdfReader(source)
def walk(items):
    for item in items:
        if isinstance(item, list):
            walk(item)
        elif item.title.startswith(('Chapter', '29.', '30.')):
            print(reader.get_destination_page_number(item)+1, item.title)
walk(reader.outline)
print(reader.pages[40].extract_text())
if importlib.util.find_spec('pypdfium2'):
    import pypdfium2 as pdfium
    doc = pdfium.PdfDocument(str(source))
    doc[4].render(scale=1.2).to_pil().save('tmp/pdfs/contents.png')
    print('RENDERED tmp/pdfs/contents.png')
