import json
import re
from pathlib import Path

root = Path.cwd()
p = json.loads((root / 'progress.json').read_text(encoding='utf-8'))
assert len(p['sessions']) == 48
assert len({s['id'] for s in p['sessions']}) == 48
assert len(p['weekly_gates']) == 8
assert p['planned_hours'] == 8 * 7 * 3 == 168
assert p['next_session_id'] == 'W1D1'
assert all(s['status'] == 'not_started' and not s['evidence'] for s in p['sessions'])
roadmap = (root / 'ROADMAP.md').read_text(encoding='utf-8')
assert all(s['id'] in roadmap for s in p['sessions'])
for md in root.glob('*.md'):
    for target in re.findall(r'\]\(([^)]+)\)', md.read_text(encoding='utf-8')):
        if not target.startswith(('https:', 'http:')):
            assert (md.parent / target).exists(), (md.name, target)
print('PASS: 48 unique sessions, 8 weekly gates, 168 hours, roadmap IDs, local links, zero initial learning progress.')
