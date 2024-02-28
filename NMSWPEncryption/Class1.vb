Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class Class1
    Public Shared Function EncryptString(ByVal key As String, ByVal plainText As String) As String
        Dim iv As Byte() = New Byte(15) {}
        Dim array As Byte()

        Using aes As Aes = Aes.Create()
            aes.Key = Encoding.UTF8.GetBytes(key)
            aes.IV = iv
            aes.Mode = CipherMode.ECB
            Dim encryptor As ICryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV)

            Using memoryStream As MemoryStream = New MemoryStream()

                Using cryptoStream As CryptoStream = New CryptoStream(CType(memoryStream, Stream), encryptor, CryptoStreamMode.Write)

                    Using streamWriter As StreamWriter = New StreamWriter(CType(cryptoStream, Stream))
                        streamWriter.Write(plainText)
                    End Using

                    array = memoryStream.ToArray()
                End Using
            End Using
        End Using

        Return Convert.ToBase64String(array)
    End Function

End Class
