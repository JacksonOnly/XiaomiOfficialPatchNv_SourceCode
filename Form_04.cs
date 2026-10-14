using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BismillahAdb;
using Newtonsoft.Json;

public class Form_04 : Form
{
    private readonly Class_04 field_322;

    private readonly string field_323 = "(error|fail|not found)";

    private IContainer field_324;

    private ImageList field_325;

    private TabControl field_326;

    private TabPage field_327;

    private RichTextBox field_328;

    private Button field_329;

    private Panel field_330;

    private ToolStrip field_331;

    private ToolStripButton field_332;

    private Button field_333;

    private TabControl field_334;

    private TabPage field_335;

    private Panel field_336;

    public Form_04()
    {
        field_322 = new Class_04();
        property_52 = new Form_03();
        property_52.ShowDialog();
        MinimumSize = new Size(709, 556);
        property_51 = new AdbClient();
        property_53 = new Class_36();
        method_357();
    }

    [field: CompilerGenerated] private AdbClient property_51 { [CompilerGenerated] get; [CompilerGenerated] set; }

    [field: CompilerGenerated] private Form_03 property_52 { [CompilerGenerated] get; [CompilerGenerated] set; }

    [field: CompilerGenerated] private Class_36 property_53 { [CompilerGenerated] get; [CompilerGenerated] set; }

    private async void method_348(object arg_01, EventArgs arg_02)
    {
        await Class_54.method_325();
        await Class_32.method_229("devices -l");
        var path = Path.Combine(Application.StartupPath, "support");
        if (!Directory.Exists(path)) return;

        var directories = new DirectoryInfo(path).GetDirectories();
        if (directories.Count() > 0)
        {
            field_328.method_364("Support Product Name list [ Patch nvram official cpid method ]", Color.Violet,
                true);
            var array = directories;
            for (var i = 0; i < array.Length; i++)
                StaticClass_04.method_364(arg_02: "\ud83d\udd39 " + array[i].Name.ToUpper(), arg_01: field_328,
                    arg_03: Color.Black);
        }
    }

    public async Task<string> method_349(AdbClient arg_01, string arg_02)
    {
        var array = new string[3]
        {
            "/dev/block/by-name/" + arg_02,
            "/dev/block/bootdevice/by-name/" + arg_02,
            "/dev/block/platform/*/by-name/" + arg_02
        };
        var array2 = array;
        foreach (var text in array2)
        {
            var text2 = await arg_01.method_317("readlink " + text);
            if (!string.IsNullOrWhiteSpace(text2) && !text2.Contains("No such file"))
            {
                if (!text2.StartsWith("/")) text2 = "/dev/block/" + text2.Trim().TrimStart('.');

                return text2.Trim();
            }
        }

        return null;
    }

    public async Task method_350(AdbClient arg_01)
    {
        var value =
            File.ReadAllText(
                new DirectoryInfo(Application.StartupPath).method_315("prop_default.json")[0]
                    .FullName);
        var dictionary =
            JsonConvert.DeserializeObject<Dictionary<string, List<string>>>(value);
        foreach (var item in dictionary)
        {
            StaticClass_04.method_363(arg_02: item.Key + ": ", arg_01: field_328);
            var arg_2 = "";
            foreach (var item2 in item.Value)
            {
                var text = await arg_01.method_317($"getprop {item2}");
                if (string.IsNullOrWhiteSpace(text) ||
                    Regex.IsMatch(text, field_323, RegexOptions.IgnoreCase)) continue;

                arg_2 = text;
                break;
            }

            field_328.method_364(arg_2);
        }
    }

    private async void method_351(object arg_01, EventArgs arg_02)
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            field_336.Enabled = false;
            field_328.Clear();
            field_328.method_363("Connecting to device [Adb] [Eng Factory] : ");
            var devices = property_51.GetDevices();
            if (devices.Count() == 0)
            {
                field_328.method_365("Failed");
                return;
            }

            var serialNumber = devices[0].SerialNumber;
            try
            {
                property_51.SetDevice(serialNumber);
                field_328.method_364($"Ok {serialNumber}", Color.Green);
                await method_350(property_51);
                var class_ = new Class_21();
                var arg_3 = class_.ChipId = await property_51.method_320();
                class_.RealCpuId = arg_3;
                var array = await property_51.method_316("getprop ro.product.device");
                if (!Regex.IsMatch(array[0], field_323, RegexOptions.IgnoreCase)) class_.Product = array[0];

                var array2 = await property_51.method_316("ro.ril.oem.imei2");
                if (!Regex.IsMatch(array2[0], field_323, RegexOptions.IgnoreCase)) class_.Imei2 = array2[0];

                var array3 = await property_51.method_316("ro.ril.oem.meid");
                if (!Regex.IsMatch(array3[0], field_323, RegexOptions.IgnoreCase)) class_.Meid = array3[0];

                var form_ = new Form_02();
                form_.property_44 = class_;
                form_.ShowDialog();
                if (!form_.property_45) return;

                var arg_4 = JsonConvert.SerializeObject(form_.property_44).method_313();
                var arg_5 = JsonConvert.SerializeObject(new Class_36.Class_40
                {
                    Criticaldata64 = arg_4,
                    Email = property_52.property_50.Email,
                    Password = property_52.property_50.Password
                }).method_313();
                var arg_6 = new Class_36.Class_42
                {
                    RequestinfoB64 = arg_5
                };
                field_328.method_363("Request CrticalDataSign from Server . ", Color.Blue, true);
                new Class_36.Class_41();
                var num = 0;
                Class_36.Class_41 class_2;
                do
                {
                    class_2 = await property_53.method_238(arg_6);
                    if (class_2.Success) break;

                    num++;
                } while (num < 3);

                if (class_2 == null || !class_2.Success) throw new Exception(JsonConvert.SerializeObject(class_2));

                field_328.method_364("Ok.");
                var text2 = Path.Combine(Application.StartupPath, "CrticalData");
                if (!Directory.Exists(text2)) Directory.CreateDirectory(text2);

                text2 = Path.Combine(text2, class_.ChipId);
                if (!Directory.Exists(text2)) Directory.CreateDirectory(text2);

                var path = text2;
                var array4 = new string[6] { class_.Product, "_", class_.Imei2, "_CrticalData_", null, null };
                var var_21 = DateTime.Now;
                var var_52 = "yyyy_Md_Hms";
                array4[4] = var_21.ToString(var_52);
                array4[5] = ".bin";
                var path2 = Path.Combine(path, string.Concat(array4));
                File.WriteAllText(path2, class_2.Data);
                field_328.method_363("Crticaldata file save to .\n");
                field_328.method_364(text2, Color.Blue);
                field_328.method_363("Remaing CreditBalance : ");
                field_328.method_364($"{class_2.Balance}", Color.Blue);
                field_328.method_363("Searching " + form_.property_44.Product + " local  from [support].");
                var array5 =
                    new DirectoryInfo(Application.StartupPath).method_314(form_.property_44.Product);
                if (array5.Count() == 0)
                {
                    field_328.method_365("Not Found.");
                    return;
                }

                field_328.method_364("Found.");
                field_328.method_363("Patching Nvram. ");
                var array6 = Array.Empty<byte>();
                var flag = false;
                var array7 = array5;
                foreach (var directoryInfo in array7)
                {
                    var files = directoryInfo.GetFiles();
                    if (files.Length == 0) continue;

                    var array8 = files;
                    foreach (var fileInfo in array8)
                    {
                        try
                        {
                            var class_3 = new Class_31(class_2.Data, fileInfo.FullName);
                            array6 = class_3.method_198();
                            flag = true;
                        }
                        catch (Exception ex)
                        {
                            var ex2 = ex;
                            Console.WriteLine("Patch failed for " + fileInfo.FullName + ": " + ex2.Message);
                            continue;
                        }

                        break;
                    }

                    if (flag) break;
                }

                if (!flag || array6.Length == 0)
                    throw new InvalidOperationException("No valid NVRAM patch was applied.");

                field_328.method_364("Ok");
                field_328.method_363("Save Patched nvram file to .\n");
                var path3 = Path.Combine(text2, "nvram.bin");
                File.WriteAllBytes(path3, array6);
                var array9 = new DirectoryInfo(Application.StartupPath).method_315("erase_nvdata");
                if (array9.Count() != 0)
                {
                    var obj = array9[0];
                    var var_53 = Path.Combine(text2, "nvdata.bin");
                    obj.CopyTo(var_53, true);
                }

                field_328.method_364(Path.GetDirectoryName(path3), Color.Blue);
                if (MessageBox.Show("Do you want to back up NVRAM data before continuing?", "NVRAM Backup",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var text3 = Path.Combine(Application.StartupPath, "Nvram_backup");
                    if (!Directory.Exists(text3)) Directory.CreateDirectory(text3);

                    var text4 = Path.Combine(text3, class_.ChipId);
                    if (!Directory.Exists(text4)) Directory.CreateDirectory(text4);

                    field_328.method_364("Start backup .", Color.Blue);
                    var array10 = new DirectoryInfo(Application.StartupPath).method_315("network.json");
                    if (array10.Count() == 0)
                        field_328.method_365("Network.json file  not found , please reinstall application.");

                    var arg = class_.Product;
                    var_21 = DateTime.Now;
                    var var_55 = "yyyy_Md_Hms";
                    var text5 = Path.Combine(text4, $"{arg}@{var_21.ToString(var_55)}");
                    if (!Directory.Exists(text5)) Directory.CreateDirectory(text5);

                    var value = File.ReadAllText(array10[0].FullName);
                    var list = JsonConvert.DeserializeObject<List<Class_70>>(value);
                    var list2 = new List<Class_70>();
                    foreach (var item in list)
                        try
                        {
                            var text6 = await method_349(property_51, item.property_56);
                            if (!Regex.IsMatch(text6, field_323, RegexOptions.IgnoreCase))
                            {
                                item.property_57 = text6;
                                list2.Add(item);
                                field_328.method_363("Backup " + item.property_56 + " -> " + text6 + " .");
                                await StaticClass_03.method_318(arg_03: Path.Combine(text5, item.property_56),
                                    arg_01: property_51, arg_02: text6);
                                field_328.method_364("Ok.");
                            }
                        }
                        catch (Exception ex3)
                        {
                            field_328.method_365(ex3.Message);
                        }

                    File.WriteAllText(Path.Combine(text5, "partition_info.json"),
                        JsonConvert.SerializeObject(list2, Formatting.Indented));
                    field_328.method_363("Save backup file to .\n");
                    field_328.method_364(text5, Color.Blue);
                }

                field_328.method_363("Start flash patched nvram to device .", Color.Blue);
                try
                {
                    var remoteFileName = await method_349(property_51, "nvram");
                    property_51.UploadData(array6, remoteFileName);
                    await StaticClass_03.method_319(arg_03: await method_349(property_51, "nvdata"),
                        arg_02: File.ReadAllBytes(array9[0].FullName), arg_01: property_51);
                    try
                    {
                        var text7 = await method_349(property_51, "proinfo");
                        if (!Regex.IsMatch(text7, field_323, RegexOptions.IgnoreCase))
                        {
                            var tempFileName = Path.GetTempFileName();
                            await property_51.method_318(text7, tempFileName);
                            var array11 = File.ReadAllBytes(tempFileName);
                            var form_2 = new Form_05();
                            form_2.ShowDialog();
                            if (form_2.property_58)
                            {
                                var bytes = Encoding.UTF8.GetBytes(form_2.property_59);
                                Array.Copy(bytes, 0, array11, 0, bytes.Length);
                                await property_51.method_319(array11, text7);
                            }
                        }
                    }
                    catch
                    {
                    }

                    await property_51.method_316("reboot");
                    field_328.method_364("Success");
                }
                catch (Exception ex4)
                {
                    field_328.method_365(ex4.Message);
                }
            }
            catch (Exception ex)
            {
                var ex5 = ex;
                field_328.method_365(ex5.Message);
            }
        }
        catch (Exception ex)
        {
            var ex6 = ex;
            field_328.method_365(ex6.Message);
        }
        finally
        {
            field_336.Enabled = true;
            Cursor = Cursors.Default;
            field_328.method_364("Process Completed.");
        }
    }

    private async void method_352(object arg_01, EventArgs arg_02)
    {
        await Task.Run(() => Process.Start("devmgmt.msc"));
    }

    private void method_353(object arg_01, EventArgs arg_02)
    {
    }

    private string method_354(string arg_01, int arg_02)
    {
        if (string.IsNullOrEmpty(arg_01)) return string.Empty;

        int var_01;
        for (var_01 = arg_02; var_01 > 0; var_01--)
        {
            var var_7 = arg_01[var_01 - 1];
            if (char.IsWhiteSpace(var_7)) break;
        }

        int i;
        for (i = arg_02; i < arg_01.Length; i++)
        {
            var var_8 = arg_01[i];
            if (char.IsWhiteSpace(var_8)) break;
        }

        return arg_01.Substring(var_01, i - var_01);
    }

    private void method_355(object arg_01, EventArgs arg_02)
    {
        var var_01 = field_328.GetCharIndexFromPosition(field_328.PointToClient(Cursor.Position));
        var var_2 = method_354(field_328.Text, var_01);
        if (Directory.Exists(var_2))
        {
            var processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = var_2;
            processStartInfo.UseShellExecute = true;
            var var_4 = "open";
            processStartInfo.Verb = var_4;
            Process.Start(processStartInfo);
        }
    }

    private async void method_356(object arg_01, EventArgs arg_02)
    {
        try
        {
            Cursor = Cursors.WaitCursor;
            field_336.Enabled = false;
            field_328.Clear();
            var class_ = new Class_21();
            var form_ = new Form_02();
            form_.property_44 = class_;
            form_.ShowDialog();
            if (!form_.property_45) return;

            var arg_3 = JsonConvert.SerializeObject(form_.property_44).method_313();
            var arg_4 = JsonConvert.SerializeObject(new Class_36.Class_40
            {
                Criticaldata64 = arg_3,
                Email = property_52.property_50.Email,
                Password = property_52.property_50.Password
            }).method_313();
            var arg_5 = new Class_36.Class_42
            {
                RequestinfoB64 = arg_4
            };
            field_328.method_363("Request CrticalDataSign from Server . ", Color.Blue, true);
            var class_2 = await property_53.method_238(arg_5);
            if (!class_2.Success) throw new Exception(JsonConvert.SerializeObject(class_2));

            field_328.method_364("Ok.");
            var text = Path.Combine(Application.StartupPath, "CrticalData");
            if (!Directory.Exists(text)) Directory.CreateDirectory(text);

            text = Path.Combine(text, class_.ChipId);
            if (!Directory.Exists(text)) Directory.CreateDirectory(text);

            var path = text;
            var array = new string[6] { class_.Product, "_", class_.Imei2, "_CrticalData_", null, null };
            var var_09 = DateTime.Now;
            var var_17 = "yyyy_Md_Hms";
            array[4] = var_09.ToString(var_17);
            array[5] = ".bin";
            var path2 = Path.Combine(path, string.Concat(array));
            File.WriteAllText(path2, class_2.Data);
            field_328.method_363("Crticaldata file save to .\n");
            field_328.method_364(text, Color.Blue);
            field_328.method_363("Remaing CreditBalance : ");
            field_328.method_364($"{class_2.Balance}", Color.Blue);
            field_328.method_363("Searching " + form_.property_44.Product + " nvram file   from local [support].");
            var array2 = new DirectoryInfo(Application.StartupPath).method_314(form_.property_44.Product);
            if (array2.Count() == 0)
            {
                field_328.method_365("Not Found.");
                return;
            }

            field_328.method_364("Found.");
            field_328.method_363("Patching Nvram. ");
            var array3 = Array.Empty<byte>();
            var flag = false;
            var array4 = array2;
            foreach (var directoryInfo in array4)
            {
                var files = directoryInfo.GetFiles();
                if (files.Length == 0) continue;

                var array5 = files;
                foreach (var fileInfo in array5)
                {
                    try
                    {
                        var class_3 = new Class_31(class_2.Data, fileInfo.FullName);
                        array3 = class_3.method_198();
                        flag = true;
                    }
                    catch (Exception ex)
                    {
                        var ex2 = ex;
                        Console.WriteLine("Patch failed for " + fileInfo.FullName + ": " + ex2.Message);
                        continue;
                    }

                    break;
                }

                if (flag) break;
            }

            if (!flag || array3.Length == 0) throw new InvalidOperationException("No valid NVRAM patch was applied.");

            field_328.method_364("Ok");
            field_328.method_363("Save Patched nvram file to .\n");
            var path3 = Path.Combine(text, "nvram.bin");
            File.WriteAllBytes(path3, array3);
            var array6 = new DirectoryInfo(Application.StartupPath).method_315("erase_nvdata");
            if (array6.Count() != 0)
            {
                var obj = array6[0];
                var var_18 = Path.Combine(text, "nvdata.bin");
                obj.CopyTo(var_18, true);
            }

            field_328.method_364(Path.GetDirectoryName(path3), Color.Blue);
        }
        catch (Exception ex)
        {
            var ex3 = ex;
            field_328.method_365(ex3.Message);
        }
        finally
        {
            Cursor = Cursors.Default;
            field_336.Enabled = true;
        }
    }

    protected override void Dispose(bool arg_01)
    {
        if (arg_01 && field_324 != null) field_324.Dispose();

        var var_02 = arg_01;
        base.Dispose(var_02);
    }

    private void method_357()
    {
        field_324 = new Container();
        var var_01 = new ComponentResourceManager(typeof(Form_04));
        field_325 = new ImageList(field_324);
        field_326 = new TabControl();
        field_327 = new TabPage();
        field_328 = new RichTextBox();
        field_329 = new Button();
        field_330 = new Panel();
        field_334 = new TabControl();
        field_335 = new TabPage();
        field_336 = new Panel();
        field_333 = new Button();
        field_331 = new ToolStrip();
        field_332 = new ToolStripButton();
        field_326.SuspendLayout();
        field_327.SuspendLayout();
        field_330.SuspendLayout();
        field_334.SuspendLayout();
        field_335.SuspendLayout();
        field_336.SuspendLayout();
        field_331.SuspendLayout();
        SuspendLayout();
        field_325.ImageStream = (ImageListStreamer)var_01.GetObject("imageList1.ImageStream");
        field_325.TransparentColor = Color.Transparent;
        field_325.Images.SetKeyName(0, "download_8292031.png");
        field_325.Images.SetKeyName(1, "Request Service.ico");
        field_325.Images.SetKeyName(2, "Request Service2.ico");
        field_326.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        field_326.Controls.Add(field_327);
        field_326.Location = new Point(7, 144);
        field_326.Name = "tabControlLogs";
        field_326.SelectedIndex = 0;
        field_326.Size = new Size(678, 327);
        field_326.TabIndex = 9;
        field_327.BorderStyle = BorderStyle.FixedSingle;
        field_327.Controls.Add(field_328);
        field_327.Location = new Point(4, 23);
        field_327.Name = "Logs";
        field_327.Padding = new Padding(3);
        field_327.Size = new Size(670, 300);
        field_327.TabIndex = 0;
        field_327.Text = "Logs";
        field_327.UseVisualStyleBackColor = true;
        field_328.BackColor = Color.White;
        field_328.BorderStyle = BorderStyle.None;
        field_328.Dock = DockStyle.Fill;
        field_328.Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_328.Location = new Point(3, 3);
        field_328.Name = "Rich";
        field_328.Size = new Size(662, 292);
        field_328.TabIndex = 15;
        field_328.Text = "";
        field_328.Click += method_355;
        field_328.TextChanged += method_353;
        field_329.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_329.ForeColor = SystemColors.MenuHighlight;
        field_329.ImageAlign = ContentAlignment.TopCenter;
        field_329.ImageIndex = 0;
        field_329.ImageList = field_325;
        field_329.Location = new Point(10, 25);
        field_329.Name = "btnPatchAdb";
        field_329.Size = new Size(85, 51);
        field_329.TabIndex = 10;
        field_329.Text = "Patch Nvram";
        field_329.TextAlign = ContentAlignment.BottomCenter;
        field_329.UseVisualStyleBackColor = true;
        field_329.Click += method_351;
        field_330.BackColor = Color.White;
        field_330.Controls.Add(field_334);
        field_330.Controls.Add(field_331);
        field_330.Controls.Add(field_326);
        field_330.Dock = DockStyle.Fill;
        field_330.Location = new Point(0, 0);
        field_330.Name = "PMain";
        field_330.Size = new Size(693, 517);
        field_330.TabIndex = 0;
        field_334.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        field_334.Controls.Add(field_335);
        field_334.Location = new Point(7, 3);
        field_334.Name = "Worktab";
        field_334.SelectedIndex = 0;
        field_334.Size = new Size(674, 135);
        field_334.TabIndex = 13;
        field_335.Controls.Add(field_336);
        field_335.Location = new Point(4, 23);
        field_335.Name = "Critical";
        field_335.Padding = new Padding(3);
        field_335.Size = new Size(666, 108);
        field_335.TabIndex = 0;
        field_335.Text = "Critical data.";
        field_335.UseVisualStyleBackColor = true;
        field_336.BackColor = Color.White;
        field_336.Controls.Add(field_333);
        field_336.Controls.Add(field_329);
        field_336.Dock = DockStyle.Fill;
        field_336.Location = new Point(3, 3);
        field_336.Name = "Pw";
        field_336.Size = new Size(660, 102);
        field_336.TabIndex = 0;
        field_333.Font = new Font("Arial", 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
        field_333.ForeColor = Color.Blue;
        field_333.ImageAlign = ContentAlignment.TopCenter;
        field_333.ImageIndex = 2;
        field_333.ImageList = field_325;
        field_333.Location = new Point(131, 25);
        field_333.Name = "btnCritical";
        field_333.Size = new Size(99, 51);
        field_333.TabIndex = 12;
        field_333.Text = "Critical Manual";
        field_333.TextAlign = ContentAlignment.BottomCenter;
        field_333.UseVisualStyleBackColor = true;
        field_333.Click += method_356;
        field_331.Dock = DockStyle.Bottom;
        var items = field_331.Items;
        var var_2 = new ToolStripItem[1] { field_332 };
        items.AddRange(var_2);
        field_331.Location = new Point(0, 492);
        field_331.Name = "toolStripButton";
        field_331.RenderMode = ToolStripRenderMode.Professional;
        field_331.Size = new Size(693, 25);
        field_331.TabIndex = 11;
        field_331.Text = "toolStrip2";
        field_332.Image = (Image)var_01.GetObject("toolStripbtnManager.Image");
        field_332.ImageTransparentColor = Color.Magenta;
        field_332.Name = "toolStripbtnManager";
        field_332.RightToLeft = RightToLeft.Yes;
        field_332.Size = new Size(112, 22);
        field_332.Text = "Device Manager";
        field_332.Click += method_352;
        AutoScaleDimensions = new SizeF(6f, 14f);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(693, 517);
        Controls.Add(field_330);
        Font = new Font("Arial", 8.25f, FontStyle.Regular, GraphicsUnit.Point, 0);
        Icon = (Icon)var_01.GetObject("$this.Icon");
        Name = "Main";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Xiaomi Patch Nvram V2 & Generate Critical data [ CPID Method ]";
        Load += method_348;
        field_326.ResumeLayout(false);
        field_327.ResumeLayout(false);
        field_330.ResumeLayout(false);
        field_330.PerformLayout();
        field_334.ResumeLayout(false);
        field_335.ResumeLayout(false);
        field_336.ResumeLayout(false);
        field_331.ResumeLayout(false);
        field_331.PerformLayout();
        ResumeLayout(false);
    }
}