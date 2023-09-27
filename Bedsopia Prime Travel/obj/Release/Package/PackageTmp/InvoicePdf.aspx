<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoicePdf.aspx.cs" Inherits="Bedsopia_Prime_Travel.InvoicePdf" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <body style='margin: 50px;'>
            <asp:Label ID="lblIslemSonuc" runat="server"></asp:Label>

        <table width='100%' height='500px' cellspacing='0' cellpadding='2'>
            <tr>
                <td>
                    <img src="C:\Users\Bosfor5\Desktop\PROJELER\BEDSOPİA\Bedsopia Prime Travel\Bedsopia Prime Travel\Images\logo.jpeg" width="75" height="50" style='text-align: left; padding: 5px;' /></td>
                <td style='text-align: right; padding: 5px;'><b>Customer<br />
                    HOTELWIZ MOBILE</b></td>
            </tr>
            <tr>
                <td colspan='2'><b>Prime Travel Service</b><br />
                    Sirinyali mah. 1539 sok Atahan Apt No:2 / 7
                <br />
                    Muratpaşa / Antalya , 7160
                <br />
                    Turkey , Turkey
                <br />
                    <b>Phone.:</b> +902423394445
                <br />
                    <b>Tax Registration No.:</b> 7330437711
                <br />
                </td>
            </tr>
        </table>
        <table width='100%' height='50px' style="margin:15px 15px 15px 15px;">
            <tr>
                <td style='border-style: solid; border-width: 1px 0px 0px 1px;'><b>Proforma invoice</b></td>
                <td style='border-style: solid; border-width: 1px 1px 0px 0px;'></td>
            </tr>
            <tr>
                <td style='border-style: solid; border-width: 0px 0px 0px 1px;'>Booking Code</td>
                <td style='font-size:15pt;'><b>71P5J6</b></td>
            </tr>
            <tr>
                <td style='border-style:solid; border-width: 0px 0px 1px 1px;'>Agency Booking Reference</td>
                <td style='border-style: solid; border-width: 0px 1px 1px 0px;'><b>HGGWP2400952</b></td>
            </tr>
        </table>
        <br />
        <br />
        <table>
            <tr style="background-color:deepskyblue;">
                <th>Booking Code</th>
                <th>Description</th>
                <th>Holder</th>
                <th>Pax</th>
                <th>Service Date</th>
                <th>Price</th>
                <th>Taxes1</th>
                <th>Total1</th>
            </tr>
            <tr>
                <td>71P5J6</td>
                <td>Rio All-Suite Hotel  Casino</td>
                <td>Jordan Nolan</td>
                <td>1</td>
                <td>Aug 29 2022 12:00AM - Sep  2 2022 12:00AM</td>
                <td>19.15</td>
                <td>0.00</td>
                <td>19.15</td>
            </tr>
            <tr>
                <td align='left' colspan='7'>SUBTOTAL (without taxes) </td>
                <td align='right'>19.15 USD</td>
            </tr>
            <tr>
                <td align='left' colspan='7'>Taxes</td>
                <td align='right'>0.00 USD</td>
            </tr>
            <tr>
                <td align='left' colspan='7'><b>Total</b></td>
                <td align='right'><b>19.15 USD</b></td>
            </tr>
        </table>
        <br />
        <br />
    </body>
</html>
