from PyQt5.QtWidgets import QApplication, QWidget, QPushButton, QVBoxLayout, QMessageBox, QLineEdit
from PyQt5.QtGui import QIcon, QPixmap
import energycalculator

app = QApplication([])
#app.setStyle('Fusion')

window = QWidget()

layout = QVBoxLayout()
button = QPushButton('Get Stats')
layout.addWidget(button)
sqFtUI = QLineEdit('Enter square footage')
residentsUI = QLineEdit('Enter Amount of Residents')
layout.addWidget(sqFtUI)
layout.addWidget(residentsUI)


def on_button_clicked():
    cost = energycalculator.calculateCost(energycalculator.calculateEnergy(int(sqFtUI.text()), int(residentsUI.text())))
    alert = QMessageBox()
    alert.setText("$%s" % str(round(cost,2)))
    alert.exec_()

button.clicked.connect(on_button_clicked)

window.setLayout(layout)
window.show()

app.exec_()