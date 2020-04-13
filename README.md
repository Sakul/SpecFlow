# SpecFlow

## ระบบตัดเกรด

| คะแนน | เกรด |
|--|--|
| 91    | A     |
| 81    | B     |
| 71    | C     |
| 61    | D     |
| 0     | F     |


### Normal cases
* ใส่ข้อมูลที่ได้คะแนน 60 จะต้องได้เกรด F
* ใส่ข้อมูลที่ได้คะแนน 70 จะต้องได้เกรด D
* ใส่ข้อมูลที่ได้คะแนน 80 จะต้องได้เกรด C
* ใส่ข้อมูลที่ได้คะแนน 90 จะต้องได้เกรด B
* ใส่ข้อมูลที่ได้คะแนน 95 จะต้องได้เกรด A
* ใส่ข้อมูลที่ได้คะแนนเกิน 90 ขึ้นไปจะต้องได้เกรด A

### Alternative cases
* ใส่ข้อมูลที่ได้คะแนน 0 จะต้องได้เกรด F
* ใส่ข้อมูลที่ได้คะแนน 61 จะต้องได้เกรด D
* ใส่ข้อมูลที่ได้คะแนน 71 จะต้องได้เกรด C
* ใส่ข้อมูลที่ได้คะแนน 81 จะต้องได้เกรด B
* ใส่ข้อมูลที่ได้คะแนน 91 จะต้องได้เกรด A

### Exception cases
* ใส่ข้อมูลที่ได้คะแนน -65 ระบบจะต้องแจ้งเตือนข้อผิดพลาด
* ใส่ข้อมูลที่ได้คะแนน 120 ระบบจะต้องแจ้งเตือนข้อผิดพลาด