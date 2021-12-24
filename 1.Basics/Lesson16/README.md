# Clases de archivos y directorios en `C#`

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Métodos de archivo

`WriteAllText(string path, string contents)` crea un nuevo archivo y escribe contenido en ese archivo. Si el archivo de destino ya existe, lo sobrescribirá:

```csharp
string path = @"C:\FileExamples\test.txt";
string content = "Example content as a string message";
File.WriteAllText(path, content);
```

`WriteAllLines(string path, string[] contents)` crea un nuevo archivo y escribe una matriz de cadenas especificada, luego cierra el archivo:

```csharp
string path = @"C:\FileExamples\WriteAllLines.txt";
string[] contentArray = new string[3] { "Example content as a string message", "Another string text", "The last string" };
File.WriteAllLines(path, contentArray);
```

`ReadAllText(string path)` abre el archivo en la ruta especificada, lee todas las líneas como una cadena y luego cierra el archivo:

```csharp
string path = @"C:\FileExamples\WriteAllLines.txt";
string readAllText = File.ReadAllText(path);
Console.WriteLine(readAllText);
```

`ReadAllLines(string path)` abre un archivo de texto, lee todas las líneas del archivo como una matriz de cadenas y luego cierra el archivo:

```csharp
string path = @"C:\FileExamples\WriteAllLines.txt";
string[] readAllLines = File.ReadAllLines(path);
foreach (string line in readAllLines)
{
    Console.WriteLine(line);
}
```

`Delete(string path)` Elimina el archivo especificado:

```csharp
string path = @"C:\FileExamples\test.txt";
File.Delete(path);
```

`Move(string sourceFileName, string destFileName)` mueve un archivo especificado a una nueva ubicación:

```csharp
string path = @"C:\FileExamples\test.txt";
string moveToPath = @"C:\FileMoveExamples\MovedFile.txt";

if(File.Exists(moveToPath)) //if the file on the target location exists, we need to remove it first.
{
    File.Delete(moveToPath);
}

File.Move(path, moveToPath);
```

`AppendAllText(string path, string contents)` abre un archivo, agrega el contenido al archivo y luego cierra el archivo. Si un archivo no existe, creará un archivo, escribirá el contenido y cerrará el archivo. Este método es útil si queremos agregar contenido nuevo sin anular el anterior:

```csharp
string path = @"C:\FileExamples\test.txt";
string content = "Append this content as a string message" + Environment.NewLine;
File.AppendAllText(path, content);
```

`AppendAllLines(string path, IEnumerable<string> contents)` agrega líneas al archivo y luego cierra el archivo:

```csharp
string path = @"C:\FileExamples\test.txt";
string[] content = new string[2] { "Append this content as a string message", "Another text line" };
File.AppendAllLines(path, content); 
```

## Métodos de directorio

`CreateDirectory(string path)` crea directorios y subdirectorios en la ubicación especificada a menos que ya existan. Devuelve un objeto DirectoryInfo para el directorio existente:

```csharp
string path = @"C:\DirectoryExample\SubDir1\SubDir2";
DirectoryInfo di = Directory.CreateDirectory(path);
Console.WriteLine($"Full name: {di.FullName}, Name: {di.Name}, Parent: {di.Parent} ...");
```

`Delete(string path)` elimina un directorio vacío de una ruta especificada:

```csharp
string path = @"C:\DirectoryExample\SubDir1\SubDir2";
Directory.Delete(path);
```

`Delete(string path, bool recursive)` elimina el directorio especificado y, si se indica, todos los subdirectorios y archivos de ese directorio:

```csharp
string path = @"C:\DirectoryExample";
Directory.Delete(path, true);
```

`Move(string sourceDirName, string destDirName)` mueve un archivo o directorio y su contenido a una nueva ubicación:

```csharp
string path = @"C:\DirectoryExample";
string moveTo = @"C:\MoveDirectory";
Directory.Move(path, moveTo);
```

## Conclusión

Bien hecho. Con este artículo, hemos terminado con los conceptos básicos de C #. En nuestro próximo módulo, hablaremos sobre conceptos orientados a objetos en C # y cómo integrarlos en nuestro código.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com