-- https://www.zebra.com/content/dam/zebra_new_ia/en-us/manuals/printers/common/programming/zpl-zbi2-pm-en.pdf
USE [ScalesDB]
GO

DECLARE @ip nvarchar(max) = '10.0.20.67'
DECLARE @port int = 9100
--DECLARE @zplCommand nvarchar(max) = '! U1 getvar "sensor.peeler"\n'
--DECLARE @zplCommand nvarchar(max) = '! U1 getvar "media.dynamic_length_calibration"\n'
DECLARE @zplCommand nvarchar(max) = '! U1 getvar "appl.link_os_version"\n'
SET @zplCommand = '! U1 getvar "appl.bootblock"\n'
SET @zplCommand = '! U1 getvar "appl.date"\n'
SET @zplCommand = '! U1 getvar "appl.name"\n'

SET @zplCommand = '! U1 getvar "device.printhead.odometer"\n'
SET @zplCommand = '! U1 getvar "device.printhead.test.detail"\n'

SET @zplCommand = '! U1 getvar "sensor.peel.gain"\n'
SET @zplCommand = '! U1 getvar "sensor.paper_supply"\n'
SET @zplCommand = '! U1 getvar "sensor.peeler"\n'
SET @zplCommand = '! U1 getvar "sensor.peel.brightness"\n'
SET @zplCommand = '! U1 getvar "sensor.peel.thold"\n'

SET @zplCommand = '! U1 getvar "sensor.head.temp"\n'
SET @zplCommand = '! U1 getvar "sensor.head.temp_celsius"\n'
SET @zplCommand = '! U1 getvar "sensor.head.temp_avg"\n'

SET @zplCommand = '! U1 getvar "sensor.gap.brightness"\n'
SET @zplCommand = '! U1 getvar "sensor.gap.gain"\n'
SET @zplCommand = '! U1 getvar "sensor.gap.offset"\n'
SET @zplCommand = '! U1 getvar "sensor.gap.thold"\n'

SET @zplCommand = '! U1 getvar "sensor.back_bar.offset"\n'
SET @zplCommand = '! U1 getvar "sensor.back_bar.cur"\n'
SET @zplCommand = '! U1 getvar "sensor.back_bar.ppr_out_thold"\n'
SET @zplCommand = '! U1 getvar "sensor.back_bar.brightness"\n'


SET @zplCommand = '! U1 getvar "print.tone"\n'

--��� ������� ��������� ��� �������� ������ ��� ������������� � ����������� ��������.
SET @zplCommand = '! U1 getvar "print.legacy_compatibility"\n'
--���������� ���������� �������� ��������� ���������� �������
SET @zplCommand = '! U1 getvar "odometer.latch_open_count"\n'
--���������� ���������� ��������, ������������ � ������� ���������� ������ ������� ������������� ��������.
SET @zplCommand = '! U1 getvar "odometer.user_label_count1"\n'
SET @zplCommand = '! U1 getvar "odometer.user_label_count2"\n'
--��� ������� ������������� ���������� ��������, ����������� �������.
SET @zplCommand = '! U1 getvar "odometer.user_total_cuts"\n'
--���������� ���������� ��������, ������������ � ������� ��������� ������� ��������� ��������
SET @zplCommand = '! U1 getvar "odometer.user_label_count"\n'

--��� ������� ���������� ����� ���������� ��������, ������������ �� ���� ������ ��������.
--������������ ����� �� �������� � ���� ������ ������ ��� ������������� ��������.
SET @zplCommand = '! U1 getvar "odometer.total_label_count"\n'
SET @zplCommand = '! U1 getvar "odometer.total_print_length"\n'
SET @zplCommand = '! U1 getvar "odometer.media_marker_count2"\n'
SET @zplCommand = '! U1 getvar "odometer.media_marker_count1"\n'
SET @zplCommand = '! U1 getvar "odometer.media_marker_count"\n'
--���������� ����� ���������� �����, ����������� �������.
SET @zplCommand = '! U1 getvar "odometer.total_cuts"\n'

--This command returns the length of the last label printed or fed (in dots).
SET @zplCommand = '! U1 getvar "odometer.label_dot_length"\n'

--��� ��������� �������� ��������� � ����� ���������� ������� ��������. ���� ������� �����������, ������� ������ �
--��������� ������ ����� ������� � ������� ��������� ������ �������
SET @zplCommand = '! U1 getvar "odometer.headnew"\n'
SET @zplCommand = '! U1 getvar "odometer.headclean"\n'

--��� ������� ��������� �������� ������ �� �������� � ������ � ������� (ips)
SET @zplCommand = '! U1 getvar "media.speed"\n'

SET @zplCommand = '! U1 getvar "media.printmode"\n'
SET @zplCommand = '! U1 getvar "media.part_number"\n'
-- ����� ���������� ����� �������� ������ � ��������:
SET @zplCommand = '! U1 getvar "media.feed_skip"\n'
--��� ������� �������� ��� ��������� ������������ ���������� �����. ��� ��������� ������� ��������� ������� ^ XS - ������������ ���������� �����
SET @zplCommand = '! U1 getvar "media.dynamic_length_calibration"\n'

--��������� ������������ ��������� ������� ���, ����� �� ������� ������ � ������� ������� �� �������� ��� ������ ����� ��������.
--����������. ��� ������� �������� ������ � ����������, �������� �������� ������ ��������.
SET @zplCommand = '! U1 getvar "media.bar_location"\n'

--��� ������� ����������, ������� ��� ������� ���������� �������
SET @zplCommand = '! U1 getvar "head.latch"\n'

--���� �������� ��������� ���������� ������� ������ � ������ �����������. ������� ������ ����� ��� ������
--"print","run", and "off"". ������ "print" � "run" ����� �������������� ��� �������� ������, ���������� ���������.
SET @zplCommand = '! U1 getvar "input.capture"\n'

SET @zplCommand = '! U1 getvar "head.darkness_switch"\n'

--��� ������� ��������� ������� ������
SET @zplCommand = '! U1 getvar "ezpl.tear_off"\n'
--��� ������� ������������� ��������� ����� �����
SET @zplCommand = '! U1 getvar "ezpl.take_label"\n'
--��� ������� �������� / ��������� ����� ��������� ������.
SET @zplCommand = '! U1 getvar "ezpl.reprint_mode"\n'
--��� ������� ������������� ������ ������ ��������.
SET @zplCommand = '! U1 getvar "ezpl.print_width"\n'

--"thermal trans" "direct thermal"
SET @zplCommand = '! U1 getvar "ezpl.print_method"\n'

--��� ������� �������������, ��� ���������� � ��������� ��� ��������� ��������. ��� ������� ������ �� ������� ^MF
--Values
--� "calibrate"
--� "feed"
--� "length"
--� "no motion"
--� "short cal"
SET @zplCommand = '! U1 getvar "ezpl.power_up_action"\n'

--��� ������� ���������� ������������ ��� ��������.��� ������� ������ �� ^ MN
--Values
--� "continuous"
--� "gap/notch"
--� "mark"
SET @zplCommand = '! U1 getvar "ezpl.media_type"\n'

--��� ������� ��������� ������������������ ������ ����������.
--! U1 setvar "ezpl.manual_calibration" ""
--! U1 do "ezpl.manual_calibration" ""

--��� ������� ������������� ��������� �������� ������ ������.
SET @zplCommand = '! U1 getvar "ezpl.label_sensor"\n'

--��� ������� ������������� ������������ ����� �������� � ������.-��� ������� ������������ ������� ^ ML
SET @zplCommand = '! U1 getvar "ezpl.label_length_max"\n'

--��� ������� �������������, ��� ���������� � ��������� ����� �������� ���������� ������� � ���������� �������� �� �����.
--Values
--� "feed" = feed to the first web after sensor
--� "calibrate" = is used to force a label length measurement and adjust the media and ribbon sensor values.
--� "length" = is used to set the label length. Depending on the size of the label, the printer feeds one or more blank labels.
--� "no motion" = no media feed
--� "short cal" = short calibration
SET @zplCommand = '! U1 getvar "ezpl.head_close_action"\n'

--���������� ���������� ���������� ������� � ������ �� ���� � ���� ������ �����.
SET @zplCommand = '! U1 getvar "head.resolution.in_dpi"\n'

--��� ������� �������� ������������� ��������.
SET @zplCommand = '! U1 getvar "device.unique_id"\n'

--��� ������� ������������� ���������� ������ ������� ������� ��������.
SET @zplCommand = '! U1 getvar "device.sensor_profile"\n'
--����������, ����� ������ �������� ����� ��������������.��� ������� ������ �� ^ JS
--Values
--� "reflective"
--� "transmissive"
--� "reflective" 
SET @zplCommand = '! U1 getvar "device.sensor_select"\n'

--����� ��� ������� ������������ �� �������, ������� ���������� ������� ��� ������ ������. �� ��������� ��������,
--���� �������� ������ ������ � ��������� ������. ��� ������� ������ �� ������� ~ HS
SET @zplCommand = '! U1 getvar "device.host_status"\n'

SET @zplCommand = '! U1 getvar "device.friendly_name"\n'

--��� ������� ��������� �������� �������� �������� ��������������, ���� ������� �� ����� �������� �����-���� ��������.
--������ � �������� ���������� ������. ���� ������������� ���������� ������ ���������, �������� ����� ��������,
--� ������� ������������� ��������������. ��� ������� ������������� ���������� �������� �
--��������� ��������, ���� ����� � ������ ��������
--Values "0" through "65535"
--Default "0" ("0" disables this feature)
SET @zplCommand = '! U1 getvar "device.download_connection_timeout"\n'




SET @zplCommand = '! U1 setvar "odometer.user_label_count2" "5"\n'
SET @zplCommand = '! U1 setvar "odometer.user_label_count1" "1" \n'


SET @zplCommand = '! U1 setvar "odometer.user_label_count" "1"\n'
SET @zplCommand = '! U1 getvar "odometer.user_label_count"\n'





-- TODO: Set parameter values here.

EXECUTE [db_scales].[ZplPipe] 
   @ip
  ,@port
  ,@zplCommand
GO


