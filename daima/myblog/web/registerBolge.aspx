<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="registerBolge.aspx.cs" Inherits="registerBolge" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 17px;
        }
        .style2
        {
            height: 24px;
        }
        h1
        {
            position:absolute;
            font-size:43px;
            color:White;
            left:475px;
            font-family:幼圆;
            top:732px;
            height: 52px;
            width: 522px;
        }
          h2
        {
            position:absolute;
            font-size:70px;
            color:Red;
            left:390px;
            font-family:Calibri;
            top:651px;
            height: 79px;
            width: 273px;
        }
        h3
        {
            position:absolute;
            font-size:20px;
            color:White;
            left:164px;
            font-family:黑体;
            top:840px;
            bottom: 32px;
        }
        wx4
        {
          position:absolute;
            font-size:20px;
            color:White;
            left:164px;
            font-family:黑体;
            top:834px;
            bottom: 80px;
        }
    
         h5
        {
            position:absolute;
            font-size:20px;
            color:White;
            left:165px;
            font-family:黑体;
            top:868px;
            height: 1px;
            width: 109px;
        }
        
         h11
        {
            position:absolute;
            font-size:20px;
            color:White;
            left:174px;
            font-family:黑体;
            top:885px;
            
        }
         h6
        {
            position:absolute;
            font-size:20px;
            color:White;
            left:167px;
            font-family:黑体;
            top:943px;
        }
          wxd7
        {
            position:absolute;
            font-size:20px;
            color:White;
            left:157px;
            font-family:黑体;
            top:950px;
        }
        w8
        {
             position:absolute;
            font-size:20px;
            color:White;
            left:480px;
            font-family:黑体;
            top:860px;
            
        }
        w9
        {
             position:absolute;
            font-size:20px;
            color:White;
            left:480px;
            font-family:黑体;
            top:900px;
            
        }
        w10
        {
             position:absolute;
            font-size:20px;
            color:White;
            left:480px;
            font-family:黑体;
            top:940px;
            
        }
        w11
        {
             position:absolute;
            font-size:20px;
            color:White;
            left:480px;
            font-family:黑体;
            top:980px;
            
        }
   
    
        
           #tw1
        {
            position:absolute;
           left:270px;
           top:860px;
        }
      
           #t2
        {
            position:absolute;
           left:270px;
           top:900px;
            height: 22px;
            width: 123px;
        }
          #t3
        {
            position:absolute;
           left:270px;
           top:950px;
        }
          #t4
        {
            position:absolute;
           left:270px;
           top:990px;
        }
          #t5
        {
            position:absolute;
           left:270px;
           top:1040px;
        }
         #t6
        {
            position:absolute;
           left:570px;
           top:860px;
        }
         #t7
        {
            position:absolute;
           left:570px;
           top:900px;
        }
         #t8
        {
            position:absolute;
           left:570px;
           top:940px;
        }
         #t9
        {
            position:absolute;
           left:570px;
           top:980px;
        }
        #t10
        {
            position:absolute;
           left:500px;
           top:1050px;
        }
        
        
        
        
    
        #tu1{
  
	position:absolute;
	left:128px;
	top:655px;
	width: 882px;
	height: 476px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="mineBolge" Runat="Server">

    <div id="tu1"><img src="image/ltbj.jpg"  id="Image1" border="0" name="Image1" width="882px" height="492px"
        alt="说明文字" /></div>

        <div style="opacity:0.55; position:absolute; left:128px; width:882px; height:492px; background-color:#333333; top: 657px;"> </div>
       

<h1> to regist your Blog</h1>
<h2>Welcome</h2>

<h3>用户名：</h3>
 <h5>密 码：<br><br>确认密码：</h5>
  <!--<h11>确认密码：</h11>-->
   <h6>姓名：<br><br>性别：</h6>
   <!-- <wxd7>性别：</wxd7>-->
    <w8>手机：</w8>
    <w9>e-mail:</w9>
    <w10>地址：</w10>
    <w11>验证码：</w11>
 <div id="tw1"><asp:TextBox ID="txtusername"  width="150px" height="22px" runat="server" ></asp:TextBox></div>

 <div id="t2"><asp:TextBox ID="txtpwd"  width="150px" height="22px" runat="server"></asp:TextBox></div>
 <div id="t3"><asp:TextBox ID="txtrepwd"  width="150px" height="22px" runat="server"></asp:TextBox></div>
 <div id="t4"><asp:TextBox ID="txtname"  width="150px" height="22px" runat="server"></asp:TextBox></div>
 <div id="t5"><asp:TextBox ID="sex"  width="150px" height="22px" runat="server"></asp:TextBox></div>
  <div id="t6"><asp:TextBox ID="txttel"  width="150px" height="22px" runat="server"></asp:TextBox></div>
 <div id="t7"><asp:TextBox ID="txtemil"  width="150px" height="22px" runat="server"></asp:TextBox></div>
 <div id="t8"><asp:TextBox ID="txtaddress"  width="150px" height="22px" runat="server"></asp:TextBox></div>
 <div id="t9"><asp:TextBox ID="txttest"  width="150px" height="22px" runat="server"></asp:TextBox></div>

 <div id="t10"><asp:Button ID="Button1" runat="server" Text="注册" width="100px" 
         height="42px" onclick="Button1_Click" BackColor="Black" BorderColor="#0066FF" 
         Font-Names="方正舒体" Font-Size="XX-Large" ForeColor="#999999" 
         BorderStyle="Groove" BorderWidth="0px" /></div>








 

 

</asp:Content>

