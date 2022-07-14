USE [ScalesDB]
GO

DECLARE @xslInput nvarchar(max)= N'<?xml version="1.0" encoding="UTF-16"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema">
<xsl:output method="text" encoding="UTF-16" omit-xml-declaration="no"/>
<xsl:decimal-format name="euro2" decimal-separator="." grouping-separator=" "/>

<xsl:template match="/">


<xsl:text>
^XA</xsl:text>

<xsl:text>
^CI28
^CWK,E:COURB.TTF
^CWL,E:COURBI.TTF
^CWM,E:COURBD.TTF
^CWN,E:COUR.TTF
^CWZ,E:ARIAL.TTF
^CWW,E:ARIALBI.TTF
^CWE,E:ARIALBD.TTF
^CWR,E:ARIALI.TTF

^LH0,10
^FWR
</xsl:text>


<!-- ������ ��������
 6 dots = 1 mm, 152 dots = 1 inch
 8 dots = 1 mm, 203 dots = 1 inch
 11.8 dots = 1 mm, 300 dots = 1 inch
 24 dots = 1 mm, 608 dots = 1 inch -->

<!--
<xsl:variable name="width" select="80" />
<xsl:variable name="length" select="98" />
 -->
<xsl:variable name="length" select="100" />
<xsl:variable name="width" select="80" />

<xsl:text>
^LL</xsl:text><xsl:value-of select="$length*11.8" />
<xsl:text>
^PW</xsl:text><xsl:value-of select="$width*11.8" />
<xsl:text>

^FO820,50
^CFZ,24,20
^FB1100,4,0,C,0
</xsl:text>
<!-- ����� ����������� -->
<xsl:text>^FH^FD</xsl:text>
<xsl:text>������������: ��� "������������ ��������" ������, 600910 ������������ ���. �.�������� ������� 13/13 ��� 20</xsl:text>
<xsl:text>^FS</xsl:text>

<xsl:text>
^FO510,50
^CFE,44,34
^FB910,4,0,J,0
</xsl:text>
<!-- ������ ������������ ������������ -->
<xsl:text>^FH^FD</xsl:text>

<xsl:variable name="GoodsFullName">
  <xsl:call-template name="string-replace-all">
    <xsl:with-param name="text" select="/WeighingFactEntity/PLU/GoodsFullName" />
    <xsl:with-param name="replace" select="''|''" />
    <xsl:with-param name="by" select="''\&amp;''" />
  </xsl:call-template>
</xsl:variable>
<xsl:value-of select="$GoodsFullName"/>

<xsl:text>^FS</xsl:text>

<xsl:text>
^FO350,50
^CFZ,36,20
^FB800,4,0,J,0
</xsl:text>
<!-- �������� ������������ -->
<xsl:text>^FH^FD</xsl:text>
<xsl:value-of select="/WeighingFactEntity/PLU/GoodsDescription"/>
<xsl:text>^FS</xsl:text>

<!-- ���� ������������ -->
<xsl:text>
^FO320,50
^CFZ,25,20
^FB270,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD���� ������������: </xsl:text>
<xsl:text>^FS</xsl:text>

<xsl:text>
^FO270,50
^CFK,56,40
^FB300,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD</xsl:text>
<xsl:variable name="dt" select="/WeighingFactEntity/ProductDate"/>
<xsl:value-of select="concat(substring($dt,9,2),''.'',substring($dt,6,2),''.'',substring($dt,1,4))"/>
<xsl:text/>
<xsl:text>^FS</xsl:text>

<!-- ���� �������� -->
<xsl:text>
^FO320,360
^CFZ,25,20
^FB270,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD����� ��: </xsl:text>
<xsl:text>^FS</xsl:text>

<xsl:text>
^FO270,360
^CFK,56,40
^FB300,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD</xsl:text>
<xsl:variable name="et" select="/WeighingFactEntity/ExpirationDate"/>
<xsl:value-of select="concat(substring($et,9,2),''.'',substring($et,6,2),''.'',substring($et,1,4))"/>
<xsl:text/>
<xsl:text>^FS</xsl:text>


<!-- ��� ����� 
<xsl:text>
^FO320,760
^CFZ,25,20
^FB100,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD���-��:^FS</xsl:text>

<xsl:text>
^FO270,760
^CFK,43,37
^FB150,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD</xsl:text>
<xsl:value-of select="/WeighingFactEntity/PLU/GoodsBoxQuantly"/>
<xsl:text>^FS</xsl:text>

<xsl:text>
^FO270,910
^CFM,42,38
^FB100,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD��^FS</xsl:text>
-->


<!-- ��� ����� -->
<xsl:text>
^FO320,700
^CFZ,25,20
^FB100,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD��� �����: ^FS</xsl:text>

<xsl:text>
^FO270,700
^CFK,56,38
^FB230,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD</xsl:text>
<xsl:variable name="netweight" select="/WeighingFactEntity/NetWeight"/>
<xsl:value-of select="format-number($netweight, ''# ###.000'', ''euro2'')"/>
<xsl:text>^FS</xsl:text>

<xsl:text>
^FO270,815
^CFK,56,38
^FB100,1,0,L,0
</xsl:text>
<xsl:text>^FH^FD��^FS</xsl:text>



<xsl:text>
^FO200,50
^CFZ,25,20
^FB200,1,0,L,0
</xsl:text>
<!-- ����� -->
<xsl:text>^FH^FD�����: </xsl:text>
<xsl:value-of select="/WeighingFactEntity/KneadingNumber"/>
<xsl:text>^FS</xsl:text>

<xsl:text>
^FO200,200
^CFZ,25,20
^FB450,1,0,L,0
</xsl:text>
<!-- ��� - ����� - ������� ���� -->
<xsl:text>^FH^FD���/�����: </xsl:text>
<xsl:value-of select="/WeighingFactEntity/Scale/Description"/>
<xsl:text>^FS
</xsl:text>

<!-- �������� CODE128 299 -->
<xsl:text>
^FO200,1000
^BCN,120,Y,N,N
^BY2
</xsl:text>
<xsl:text>^FD</xsl:text>
<xsl:text>299</xsl:text>
<!-- �������� -->
<xsl:variable name="deviceid" select="/WeighingFactEntity/Scale/DeviceId"/>
<xsl:value-of select="substring(concat(''00000'',$deviceid),string-length($deviceid)+1,5)"/>
<!-- �����������  -->
<xsl:variable name="unitid" select="/WeighingFactEntity/Sscc/UnitID"/>
<xsl:value-of select="substring(concat(''00000000'',$unitid),string-length($unitid)+1,8)"/>
<xsl:text>^FS
</xsl:text>

<!-- �������� Code128  -->
<xsl:text>
^FO740,50
^BY2
^BCR,120,Y,N,N

</xsl:text>
<xsl:text>^FD</xsl:text>
<xsl:text>298</xsl:text>

<!-- �������� -->
<xsl:value-of select="substring(concat(''00000'',$deviceid),string-length($deviceid)+1,5)"/>
<!-- �����������  -->
<xsl:value-of select="substring(concat(''00000000'',$unitid),string-length($unitid)+1,8)"/>
<!-- ���� -->
<xsl:variable name="dt2" select="/WeighingFactEntity/ProductDate"/>
<xsl:value-of select="concat(substring($dt2,3,2), substring($dt2,6,2), substring($dt2,9,2) )"/>
<!-- ����� -->
<xsl:variable name="tm" select="/WeighingFactEntity/RegDate"/>
<xsl:value-of select="concat(substring($tm,12,2), substring($tm,15,2), substring($tm,18,2) )"/>
<!-- ��� -->
<xsl:variable name="plu" select="/WeighingFactEntity/PLU/PLU"/>
<xsl:value-of select="substring(concat(''000'',$plu),string-length($plu)+1,3)"/>

<!-- ScaleFactor -->
<xsl:variable name="sf" select="/WeighingFactEntity/ScaleFactor"/>

<!-- ����� -->
<xsl:variable name="nw" select="/WeighingFactEntity/NetWeight"/>
<xsl:value-of select="substring(concat(''00000'',$nw * $sf),string-length($nw*$sf)+1,5)"/>

<xsl:variable name="knd" select="/WeighingFactEntity/KneadingNumber"/>
<xsl:value-of select="substring(concat(''000'',$knd),string-length($knd)+1,3)"/>

<xsl:text>^FS
</xsl:text>

<!-- �������� GS1 -->
<xsl:text>
^FO50,50
^BCR,120,Y,N,Y,D
^BY3
</xsl:text>
<xsl:text>^FD</xsl:text>
<xsl:text>(01)</xsl:text><xsl:value-of select="/WeighingFactEntity/PLU/GTIN"/>
<xsl:text>(3103)</xsl:text><xsl:value-of select="substring(concat(''000000'',$nw * $sf),string-length($nw*$sf)+1,6)"/>
<xsl:variable name="xt" select="/WeighingFactEntity/ProductDate"/>
<xsl:text>(11)</xsl:text><xsl:value-of select="concat(substring($xt,3,2), substring($xt,6,2), substring($xt,9,2) )"/>
<xsl:text>(10)</xsl:text><xsl:value-of select="concat(substring($xt,6,2), substring($xt,9,2) )"/><xsl:text>&gt;8</xsl:text>
<!-- ����� �� ������� 
<xsl:text>(21)</xsl:text><xsl:value-of select="substring(concat(''000000000'',$unitid),string-length($unitid)+1,9)"/><xsl:text>&gt;8</xsl:text>
-->
<xsl:text>^FS
</xsl:text>

<!-- �������� -->
<xsl:text>
^FO200,888
^XGE:EAC.GRF,1,1^FS
^FO315,888
^XGE:FISH.GRF,1,1^FS
^FO435,888
^XGE:TEMP6.GRF,1,1^FS
</xsl:text>

<xsl:text>
^XZ</xsl:text><xsl:text>
</xsl:text>
</xsl:template>


<xsl:template name="string-replace-all">
  <xsl:param name="text" />
  <xsl:param name="replace" />
  <xsl:param name="by" />
  <xsl:choose>
    <xsl:when test="contains($text, $replace)">
      <xsl:value-of select="substring-before($text,$replace)" />
      <xsl:value-of select="$by" />
      <xsl:call-template name="string-replace-all">
        <xsl:with-param name="text" select="substring-after($text,$replace)" />
        <xsl:with-param name="replace" select="$replace" />
        <xsl:with-param name="by" select="$by" />
      </xsl:call-template>
    </xsl:when>
    <xsl:otherwise>
      <xsl:value-of select="$text" />
    </xsl:otherwise>
  </xsl:choose>
</xsl:template>

</xsl:stylesheet>
'
DECLARE @xmlInput nvarchar(max) = N'<?xml version="1.0" encoding="utf-16"?>
<WeighingFactEntity>
	<ScaleId>E3ED0806-DBCA-11EA-BC43-AC1F6B02AD52</ScaleId>
	<Scale>
		<DeviceId>13</DeviceId>
		<RRefID>E3ED0806-DBCA-11EA-BC43-AC1F6B02AD52</RRefID>
		<Description>Line 13 (��01)</Description>
		<DeviceIP>192.168.0.243</DeviceIP>
		<DeviceMAC>4CCC6A93A440</DeviceMAC>
		<DevicePort>5100</DevicePort>
		<DeviceSendTimeout>100</DeviceSendTimeout>
		<DeviceReceiveTimeout>100</DeviceReceiveTimeout>
		<DeviceComPort>COM6</DeviceComPort>
		<ZebraIP>192.168.3.193</ZebraIP>
		<ZebraPort>9100</ZebraPort>
		<UseOrder>false</UseOrder>
		<ScaleFactor>0</ScaleFactor>
		<TemplateIdDefault>CEE481F7-C806-11EA-BC3F-AC1F6B02AD52</TemplateIdDefault>
	</Scale>
	<PLU>
		<Id>65</Id>
		<PLU>130</PLU>
		<RRefGoods>55EA4A26-C376-11E6-80D0-A4BF01016D50</RRefGoods>
		<ScaleId>E3ED0806-DBCA-11EA-BC43-AC1F6B02AD52</ScaleId>
		<GoodsName>��������� �.�.</GoodsName>
		<GoodsDescription>���� ��������: 30 ����� ��� ����������� �� 0�� �� +6�� � ������������� ��������� ������� 75%-78%. ��������� ��� ��������.</GoodsDescription>
		<GoodsFullName>������� ��������� ������-��������. ������� ������ ��������� �. ������� ������-�������� "�������� ���������" ����������� �� 10.13.14-003-91005552-2015</GoodsFullName>
		<GTIN>02600108000001</GTIN>
		<GoodsShelfLifeDays>30</GoodsShelfLifeDays>
		<GoodsTareWeight>0.735</GoodsTareWeight>
		<GoodsFixWeight>0</GoodsFixWeight>
		<GoodsBoxQuantly>25</GoodsBoxQuantly>
		<TemplateID>76F82A3C-CA90-11EA-BC40-AC1F6B02AD52</TemplateID>
		<Template>
			<Title>Template80x100weight_CODE128_300dpi</Title>
			<TemplateId>76F82A3C-CA90-11EA-BC40-AC1F6B02AD52</TemplateId>
		</Template>
		<GLN>0</GLN>
	</PLU>
	<ProductDate>2020-10-06T14:47:04.03415+03:00</ProductDate>
	<ExpirationDate>2020-11-05T14:47:04.03415+03:00</ExpirationDate>
	<KneadingNumber>1</KneadingNumber>
	<NetWeight>1.205</NetWeight>
	<TareWeight>0.735</TareWeight>
	<GrossWeight>1.940</GrossWeight>
	<ScaleFactor>1000</ScaleFactor>
	<RegDate>2020-10-06T14:48:08.413</RegDate>
	<Sscc>
		<SSCC>00146071002300164560</SSCC>
		<GLN>460710023</GLN>
		<UnitID>16456</UnitID>
		<UnitType>1</UnitType>
		<SynonymSSCC>(00)146071002300164560</SynonymSSCC>
		<Check>0</Check>
	</Sscc>
</WeighingFactEntity>'


-- TODO: ������� ����� �������� ����������.

EXECUTE [db_scales].[XSLTTransform] 
   @xslInput
  ,@xmlInput
GO


