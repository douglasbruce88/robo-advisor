open System
open System.Windows.Forms
open ChartsAndData

Application.EnableVisualStyles()
Application.SetCompatibleTextRenderingDefault false
[<STAThread>]
do Application.Run(Form.load())
