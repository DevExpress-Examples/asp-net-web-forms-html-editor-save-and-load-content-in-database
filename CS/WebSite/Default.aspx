<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v10.2, Version=10.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript" language="javascript">
        function OnCustomCommand(s, e) {
            switch (e.commandName) {
                case 'Save':
                    s.PerformDataCallback (e.commandName, function() { });
                    break;
                case 'Load':
                    document.location.reload(true);
                    break;
            }
        }
    </script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxHtmlEditor ID="htmlEditor" runat="server" ClientInstanceName="he" OnCustomDataCallback="htmlEditor_CustomDataCallback">
                <Toolbars>
                    <dx:HtmlEditorToolbar>
                        <Items>
                            <dx:CustomToolbarButton CommandName="Save" ViewStyle="Image" ToolTip="Save">
                                <Image Url="Images/Save.png" Width="32px" Height="32px">
                                </Image>
                            </dx:CustomToolbarButton>
                            <dx:CustomToolbarButton CommandName="Load" ViewStyle="Image" ToolTip="Re-Load Page">
                                <Image Url="Images/Load.png" Width="32px" Height="32px">
                                </Image>
                            </dx:CustomToolbarButton>
                        </Items>
                    </dx:HtmlEditorToolbar>
                </Toolbars>
                <ClientSideEvents CustomCommand="OnCustomCommand" />
            </dx:ASPxHtmlEditor>
        </div>
    </form>
</body>
</html>
