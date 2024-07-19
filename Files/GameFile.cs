using Falcon_Flight_Planner.Enums;
using Falcon_Flight_Planner.Utilities;
using FalconDatabase.Enums;
using System;
using System.IO;
using System.Security;
using System.Windows;

namespace FalconDatabase.Files
{
    /// <summary>
    /// Base Class for all Game Files.
    /// </summary>
    public abstract class GameFile : IEquatable<GameFile>
    {

        #region Properties
        /// <summary>
        /// The Name of the <see cref="GameFile"/> this object represents.
        /// </summary>
        public string? FileName { get { return _FileInfo?.Name; } }
        /// <summary>
        /// The Path of the <see cref="GameFile"/> this object represents.
        /// </summary>
        public string? FilePath { get { return _FileInfo?.DirectoryName; } }
        /// <summary>
        /// The Extension of the <see cref="GameFile"/> this object represents.
        /// </summary>
        public string? FileExtension { get { return _FileInfo?.Extension; } }
        /// <summary>
        /// The Full Path and File Name of the <see cref="GameFile"/> this object represents.
        /// </summary>
        public string? FullName { get { return _FileInfo?.FullName; } }
        /// <summary>
        /// The Length of the <see cref="GameFile"/> this object represents.
        /// </summary>
        public long Length { get { return _FileInfo is null ? 0 : _FileInfo.Length; } }
        /// <summary>
        /// The type of <see cref="GameFile"/> this object represents.
        /// </summary>
        public GameFileType FileType { get { return _FileType; } }
        /// <summary>
        /// When <see langword="true"/>, indicates the data within this file is stored in a compressed state using LZSS.
        /// </summary>
        public bool IsCompressed
        { get { return _IsCompressed; } }
        /// <summary>
        /// Inidicates if the underlying File has been modified.
        /// </summary>
        public bool IsFileModified
        {
            get { return _InitialHash != GetHashCode(); }
        }
        /// <summary>
        /// <para>When <see langword="true"/>, indicates this <see cref="GameFile"/> was successfully loaded from the file.</para>
        /// <para><see langword="false"/> indicates there were no values in the initialization data used for this <see cref="GameFile"/> object and empty or default values were loaded instead.</para>
        /// </summary>       
        public abstract bool IsDefaultInitialization
        { get; }

        #endregion Properties

        #region Fields        
        protected bool _IsFileModified = false; // TODO: Implement this with Hash Validation
        protected GameFileType _FileType = GameFileType.NONE;
        protected FileStreamType _StreamType = FileStreamType.Text;
        protected FileInfo? _FileInfo;
        protected bool _IsCompressed = false;
        protected int _InitialHash = 0;
        #endregion Fields

        #region Helper Methods

        /// <summary>
        /// Opens a File Picker Dialog Box
        /// </summary>
        /// <param name="filter"><para>A <see cref="string"/> filter to apply to valid file extension types.</para>
        /// <para>Format: [Name to show] (*.[File Extension])|*.[File Extension]|[File Type 2 format]</para></param>
        /// <param name="defaultFileType">Sets the filter <see cref="string"/> that determines what types of files are displayed
        ///     in the Dialog.</param>
        /// <returns>If the user double clicks a file or clicks the OK button of the dialog that is displayed 
        /// (e.g. <see cref="Microsoft.Win32.OpenFileDialog"/>, <see cref="Microsoft.Win32.SaveFileDialog"/>), <see langword="true"/> is 
        /// returned; otherwise, <see langword="false"/>.</returns>
        protected FileInfo? OpenFile(string filter = "All Files (*.*)|*.*", string defaultFileType = ".*")
        {
            Microsoft.Win32.OpenFileDialog dlg = new()
            {
                // Set filter for file extension and default file extension 
                DefaultExt = defaultFileType,
                Filter = filter
            };

            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();

            // Get the selected file 
            if (result == true)
            {
                return new FileInfo(dlg.FileName);
            }

            return null;
        }
        /// <summary>
        /// Opens a File Save Dialog Box
        /// </summary>
        /// <param name="filter"><para>A <see cref="string"/> filter to apply to valid file extension types.</para>
        /// <para>Format: [Name to show] (*.[File Extension])|*.[File Extension]|[File Type 2 format]</para></param>
        /// <param name="defaultFileType">Sets the filter <see cref="string"/> that determines what types of files are displayed
        ///     in the Dialog.</param>
        /// <returns>If the user double clicks a file or clicks the OK button of the dialog that is displayed 
        /// (e.g. <see cref="Microsoft.Win32.OpenFileDialog"/>, <see cref="Microsoft.Win32.SaveFileDialog"/>), <see langword="true"/> is 
        /// returned; otherwise, <see langword="false"/>.</returns>
        protected FileInfo? SaveFile(string filter = "All Files (*.*)|*.*", string defaultFileType = ".*")
        {
            Microsoft.Win32.SaveFileDialog dlg = new()
            {
                // Set filter for file extension and default file extension 
                DefaultExt = defaultFileType,
                Filter = filter
            };

            // Display OpenFileDialog by calling ShowDialog method 
            bool? result = dlg.ShowDialog();

            // Get the selected file
            if (result == true)
            {
                return new FileInfo(dlg.FileName);
            }

            return null;

        }
        /// <summary>
        /// Attempts to initialze the <see cref="GameFile"/> object from the text in <paramref name="data"/>.
        /// </summary>
        /// <param name="data">A <see cref="string"/> object data formatted as text for this <see cref="Gamefile"/></param>
        /// <returns><para><see langword="true"/> if the <see cref="GameFile"/> is successfully initialized, otherwise <see langword="false"/>.</para>
        /// <para>If initialization fails due to a <see cref="FileFormatException"/>, a default instance of the object is created.</para></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected virtual bool Read(string data)
        {
            throw new InvalidDataException("This File Type requires binary data.");
        }
        /// <summary>
        /// Attempts to initialze the <see cref="GameFile"/> object from the <see cref="byte[]"/> in <paramref name="data"/>.
        /// </summary>
        /// <param name="data">A <see cref="byte"/> array initialization data for this <see cref="Gamefile"/></param>
        /// <returns><para><see langword="true"/> if the <see cref="GameFile"/> is successfully initialized, otherwise <see langword="false"/>.</para>
        /// <para>If initialization fails due to a <see cref="FileFormatException"/>, a default instance of the object is created.</para></returns>
        /// <exception cref="NotImplementedException"></exception>
        protected virtual bool Read(byte[] data)
        {
            throw new InvalidDataException("This File Type requires string data.");
        }
        /// <summary>
        /// Formats and arranges the Data within this <see cref="GameFile"/> object for writing to a file on disk.
        /// </summary>
        /// <returns><see cref="byte[]"/> that can be written to a file</returns>
        protected abstract byte[] Write();
        #endregion Helper Methods

        #region Functional Methods
        /// <summary>
        /// Attempts to read and parse the Data from the <see cref="File"/> located at <paramref name="path"/>.
        /// </summary>
        /// <param name="path">The File to read</param>
        /// <returns><para><see langword="true"/> if the caller has the required permissions and <paramref name="path"/> contains the name of an existing file which is successfully parsed; otherwise, <see langword="false"/>.</para>
        /// <para>This method also returns <see langword="false"/> if <paramref name="path"/> is null, an invalid path, or a zero-length string. If the caller does not have sufficient permissions to read the specified file, 
        /// no exception is thrown and the method returns <see langword="false"/> regardless of the existence of path.</para></returns>
        public bool Load(string path)
        {

            try
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(path);
                if (!File.Exists(path)) throw new FileNotFoundException("The file " + path + "could not be found.");

                bool result = false;
                switch (_StreamType)
                {
                    case FileStreamType.XML:
                    case FileStreamType.Text:
                        {
                            result = Read(File.ReadAllText(path));

                            break;
                        }
                    case FileStreamType.Binary:
                        {
                            result = Read(File.ReadAllBytes(path));

                            break;

                        }
                    case FileStreamType.ProtoBuff:
                        {
                            string msg = "Protobuff Read functionality has not been fully implemented yet.";
                            MessageBox.Show(msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            throw new NotImplementedException(msg);
                        }
                }

                if (!result) throw new SecurityException("Unable to access the file at " + path);
                _FileInfo = new FileInfo(path);
                return true;

            }
            catch (Exception ex)
            {
                Logging.ErrorLogging.CreateLogFile(ex, "This error occurred while attempting to load " + path + Environment.NewLine + "File Type: " + FileType + Environment.NewLine + "Stream Type: " + _StreamType);
                if (ex.GetType() == typeof(IOException))
                    return false;
                if (ex.GetType() == typeof(FileFormatException))
                {
                    if (MessageBox.Show("File at " + path + " did not contain the correct type of data. Would you like to select a different File to open?", "Invalid File", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                        return Load();

                    return false;
                }
                if (ex.GetType() == typeof(ArgumentNullException))
                {
                    if (MessageBox.Show("File Name cannot be empty. Would you like to select a File to open?", "Invalid File", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                        return Load();

                    return false;
                }
                if (ex.GetType() == typeof(FileNotFoundException))
                {
                    if (MessageBox.Show("File " + path + " could not be found. Would you like to select a different File to open?", "Invalid File", MessageBoxButton.YesNo, MessageBoxImage.Error) == MessageBoxResult.Yes)
                        return Load();

                    return false;
                }
                if (ex.GetType() == typeof(SecurityException))
                {
                    MessageBox.Show("Unable to open " + path + ".", "Insufficient Permissions", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                throw;
            }

        }
        /// <summary>
        /// Opens a <see cref="Microsoft.Win32.OpenFileDialog"/> dialog to allow the user to select a game file to read parameters from.
        /// </summary>
        public bool Load()
        {
            _FileInfo = OpenFile();
            if (_FileInfo is not null && !string.IsNullOrEmpty(FullName))
                return Load(_FileInfo.FullName);

            return false;
        }
        /// <summary>
        /// Attempts to open or create the file at <paramref name="path"/> and write the contents of this file to it.
        /// </summary>
        /// <param name="path">File name to write the data to.</param>
        /// <returns><see langword="true"/> if the file was successfully saved, <see langword="false"/> otherwise.</returns>
        /// <exception cref="NotImplementedException">Indicates the Save funciton is not implemented for this file type yet.</exception>
        public virtual bool Save(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
                return false;

            byte[] data = Write();

            if (data is null || data.Length == 0) return false;

            try
            {
                File.WriteAllBytes(path, data);
            }
            catch (Exception ex)
            {
                Logging.ErrorLogging.CreateLogFile(ex, "This error occurred while attempting to write to " + path + Environment.NewLine + "File Type: " + FileType + Environment.NewLine + "Stream Type: " + _StreamType);
                if (ex.GetType() == typeof(IOException))
                {
                    MessageBox.Show("The write operation failed.", "Save Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                if (ex.GetType() == typeof(SecurityException))
                {
                    MessageBox.Show("Unable to open " + path + ".", "Insufficient Permissions", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
                throw;
            }


            // File successfully written
            // Update the Modified indicator bool since this is now the current data
            _IsFileModified = false;
            // Set the new File reference to the file that was written to
            _FileInfo = new FileInfo(path);
            // Notify caller of success
            return true;
        }
        /// <summary>
        /// Attempts to save the current File to disk. If the File does not have a File Name associate, opens a <see cref="Microsoft.Win32.SaveFileDialog"/> and writes data to the selected file.
        /// </summary>
        /// <returns><see langword="true"/> if the file was successfully saved, <see langword="false"/> otherwise.</returns>
        public bool Save()
        {
            if (_FileInfo is null || string.IsNullOrWhiteSpace(_FileInfo.FullName))
                _FileInfo = SaveFile();

            if (_FileInfo is not null)
                return Save(_FileInfo.FullName);

            return false;
        }
        /// <summary>
        /// Opens a <see cref="Microsoft.Win32.SaveFileDialog"/> and writes data to the selected file.
        /// </summary>
        /// <returns><see langword="true"/> if the file was successfully saved, <see langword="false"/> otherwise.</returns>
        public bool SaveAs()
        {
            _FileInfo = SaveFile();
            if (_FileInfo is not null)
                return Save(_FileInfo.FullName);
            return false;
        }
        /// <summary>
        /// <para>Formats the data contained within the <see cref="GameFile"/> object into Readable Text.</para>
        /// <para>Readable Text does not always match the underlying file format and should not be used to save text based files such as .ini, .lst, or .txtpb files.</para>
        /// <para>Instead, use Write() to format all text or binary data for writing to a file.</para>
        /// </summary>
        /// <returns>A formatted <see cref="string"/> with the Data contained within the <see cref="GameFile"/> object.</returns>
        public new abstract string ToString();

        #region Equality Methods
        public virtual bool Equals(GameFile? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            if (other.GetType() != GetType()) return false;

            return other.ToString() == ToString() && other.GetHashCode() == GetHashCode();
        }
        public abstract override bool Equals(object? other);
        public abstract override int GetHashCode();
        public static bool operator ==(GameFile comparator1, GameFile comparator2)
        {
            if ((object)comparator1 == null || (object)comparator2 == null)
                return Equals(comparator1, comparator2);

            return comparator1.Equals(comparator2);
        }
        public static bool operator !=(GameFile comparator1, GameFile comparator2)
        {
            if ((object)comparator1 == null || (object)comparator2 == null)
                return !Equals(comparator1, comparator2);

            return !comparator1.Equals(comparator2);
        }

        #endregion Equality Methods

        #endregion Functional Methods

        #region Constructors

        #endregion Constructors

    }
}
