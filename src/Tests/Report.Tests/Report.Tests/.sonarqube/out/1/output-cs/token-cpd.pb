Ü
fC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Controllers\ReportController.cs
	namespace 	
Report
 
. 
API 
. 
Controllers  
{ 
[		 
ApiController		 
]		 
[

 
Route

 

(


 
$str

 
)

 
]

 
public 

class 
ReportController !
:" #
ControllerBase$ 2
{ 
private 
readonly 
IReportService '
_reportService( 6
;6 7
public 
ReportController 
(  
IReportService  .
reportService/ <
)< =
{ 	
_reportService 
= 
reportService *
;* +
} 	
[ 	
HttpGet	 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
IEnumerable% 0
<0 1
ReportResult1 =
>= >
)> ?
,? @
(A B
intB E
)E F
HttpStatusCodeF T
.T U
OKU W
)W X
]X Y
public 
async 
Task 
< 
ActionResult &
<& '
IEnumerable' 2
<2 3
ReportResult3 ?
>? @
>@ A
>A B
GetC F
(F G
)G H
{ 	
var 
reports 
= 
await 
_reportService  .
.. /
GetAsync/ 7
(7 8
)8 9
;9 :
return 
Ok 
( 
reports 
) 
; 
} 	
[ 	
HttpGet	 
( 
$str 
, 
Name 
= 
$str  +
)+ ,
], -
public 
async 
Task 
< 
ActionResult &
<& '
ReportResult' 3
>3 4
>4 5
Get6 9
(9 :
string: @
idA C
)C D
{ 	
ReportResult   
?   
report    
=  ! "
await  # (
_reportService  ) 7
.  7 8
GetAsync  8 @
(  @ A
id  A C
)  C D
;  D E
return"" 
report"" 
is"" 
null"" !
?""" #
(""$ %
ActionResult""% 1
<""1 2
ReportResult""2 >
>""> ?
)""? @
NotFound""@ H
(""H I
)""I J
:""K L
(""M N
ActionResult""N Z
<""Z [
ReportResult""[ g
>""g h
)""h i
Ok""i k
(""k l
report""l r
)""r s
;""s t
}## 	
[%% 	
HttpPost%%	 
]%% 
[&& 	
Route&&	 
(&& 
$str&& 
)&& 
]&& 
public'' 
async'' 
Task'' 
<'' 
ActionResult'' &
>''& '
CreateReportRequest''( ;
(''; <
)''< =
{(( 	
await)) 
_reportService))  
.))  !
CreateReportRequest))! 4
())4 5
)))5 6
;))6 7
return++ 
Ok++ 
(++ 
)++ 
;++ 
},, 	
}-- 
}.. ˜
]C:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Data\IReportContext.cs
	namespace 	
Report
 
. 
API 
. 
Data 
{ 
public 

	interface 
IReportContext #
{ 
IMongoCollection 
< 
ReportResult %
>% &
ReportResults' 4
{5 6
get7 :
;: ;
}< =
}		 
}

 ≤
\C:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Data\ReportContext.cs
	namespace 	
Report
 
. 
API 
. 
Data 
{ 
public 

class 
ReportContext 
:  
IReportContext! /
{ 
public 
ReportContext 
( 
IConfiguration +
configuration, 9
)9 :
{		 	
MongoClient

 
client

 
=

  
new

! $
(

$ %
configuration

% 2
.

2 3
GetValue

3 ;
<

; <
string

< B
>

B C
(

C D
$str

D g
)

g h
)

h i
;

i j
IMongoDatabase 
database #
=$ %
client& ,
., -
GetDatabase- 8
(8 9
configuration9 F
.F G
GetValueG O
<O P
stringP V
>V W
(W X
$strX w
)w x
)x y
;y z
ReportResults 
= 
database $
.$ %
GetCollection% 2
<2 3
ReportResult3 ?
>? @
(@ A
configurationA N
.N O
GetValueO W
<W X
stringX ^
>^ _
(_ `
$str	` Å
)
Å Ç
)
Ç É
;
É Ñ
} 	
public 
IMongoCollection 
<  
ReportResult  ,
>, -
ReportResults. ;
{< =
get> A
;A B
}C D
} 
} §
]C:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Entities\ReportData.cs
	namespace 	
Report
 
. 
API 
. 
Entities 
{ 
public 

class 

ReportData 
{ 
public 
string 
Location 
{  
get! $
;$ %
set& )
;) *
}+ ,
public 
string 
ContactCount "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
string 
PhoneNumberCount &
{' (
get) ,
;, -
set. 1
;1 2
}3 4
}		 
} ï
_C:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Entities\ReportResult.cs
	namespace 	
Report
 
. 
API 
. 
Entities 
{ 
public 

class 
ReportResult 
{ 
[ 	
BsonId	 
] 
[		 	
BsonRepresentation			 
(		 
BsonType		 $
.		$ %
ObjectId		% -
)		- .
]		. /
public

 
string

 
Id

 
{

 
get

 
;

 
set

  #
;

# $
}

% &
public 
DateTime 
CreatedDate #
{$ %
get& )
;) *
set+ .
;. /
}0 1
public 
Status 
Status 
{ 
get "
;" #
set$ '
;' (
}) *
public 
string 
	ReportUrl 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
Title 
{ 
get !
;! "
set# &
;& '
}( )
public 
string 
QueueId 
{ 
get  #
;# $
set% (
;( )
}* +
} 
public 

enum 
Status 
{ 

Prepraring 
= 
$num 
, 
Done 
= 
$num 
, 
} 
} ˜
oC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\EventBusConsumer\ReportCreateConsumer.cs
	namespace 	
Report
 
. 
API 
. 
EventBusConsumer %
{ 
public 

class  
ReportCreateConsumer %
:& '
	IConsumer( 1
<1 2
ReportCreateEvent2 C
>C D
{		 
private

 
readonly

 
ILogger

  
<

  ! 
ReportCreateConsumer

! 5
>

5 6
_logger

7 >
;

> ?
private 
readonly 
IReportService '
_reportService( 6
;6 7
public  
ReportCreateConsumer #
(# $
IReportService$ 2
reportService3 @
,@ A
ILoggerB I
<I J 
ReportCreateConsumerJ ^
>^ _
logger` f
)f g
{ 	
_reportService 
= 
reportService *
;* +
_logger 
= 
logger 
; 
} 	
public 
async 
Task 
Consume !
(! "
ConsumeContext" 0
<0 1
ReportCreateEvent1 B
>B C
contextD K
)K L
{ 	
await 
_reportService  
.  !
CreateReport! -
(- .
context. 5
:5 6
context7 >
.> ?
Message? F
)F G
;G H
_logger 
. 
LogInformation "
(" #
$str# 4
)4 5
;5 6
} 	
} 
} ã
iC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\EventBusEvent\ReportCreateEvent.cs
	namespace 	
Report
 
. 
API 
. 
EventBusEvent "
{ 
public

 

class

 
ReportCreateEvent

 "
:

# $ 
IntegrationBaseEvent

% 9
{ 
public 
ReportResult 
Report "
{# $
get% (
;( )
set* -
;- .
}/ 0
public 
List 
< $
GetContactsResponseModel ,
>, -
Contacts. 6
{7 8
get9 <
;< =
set> A
;A B
}C D
} 
} ≥
cC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Helper\GoogleSheetsHelper.cs
	namespace 	
Report
 
. 
API 
. 
Helper 
{ 
public 

class 
GoogleSheetsHelper #
{ 
public		 
SheetsService		 
Service		 $
{		% &
get		' *
;		* +
set		, /
;		/ 0
}		1 2
private 
const 
string 
APPLICATION_NAME -
=. /
$str0 =
;= >
private 
static 
readonly 
string  &
[& '
]' (
Scopes) /
=0 1
{2 3
SheetsService4 A
.A B
ScopeB G
.G H
SpreadsheetsH T
}U V
;V W
public 
GoogleSheetsHelper !
(! "
)" #
{ 	
InitializeService 
( 
) 
;  
} 	
private 
void 
InitializeService &
(& '
)' (
{ 	
GoogleCredential 

credential '
=( )"
GetCredentialsFromFile* @
(@ A
)A B
;B C
Service 
= 
new 
SheetsService '
(' (
new( +
BaseClientService, =
.= >
Initializer> I
(I J
)J K
{ !
HttpClientInitializer %
=& '

credential( 2
,2 3
ApplicationName 
=  !
APPLICATION_NAME" 2
} 
) 
; 
} 	
private 
static 
GoogleCredential '"
GetCredentialsFromFile( >
(> ?
)? @
{ 	
GoogleCredential 

credential '
;' (
using   
(   

FileStream   
stream   $
=  % &
new  ' *
(  * +
$str  + @
,  @ A
FileMode  B J
.  J K
Open  K O
,  O P

FileAccess  Q [
.  [ \
Read  \ `
)  ` a
)  a b
{!! 

credential"" 
="" 
GoogleCredential"" -
.""- .

FromStream"". 8
(""8 9
stream""9 ?
)""? @
.""@ A
CreateScoped""A M
(""M N
Scopes""N T
)""T U
;""U V
}## 
return$$ 

credential$$ 
;$$ 
}%% 	
}&& 
}'' ◊$
]C:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Helper\ReportMapper.cs
	namespace 	
Report
 
. 
API 
. 
Helper 
{ 
public 

static 
class 
ReportMapper $
{ 
public 
static 
List 
< 

ReportData %
>% &
MapFromRangeData' 7
(7 8
IList8 =
<= >
IList> C
<C D
objectD J
>J K
>K L
valuesM S
)S T
{ 	
List		 
<		 

ReportData		 
>		 
reportDatas		 (
=		) *
new		+ .
(		. /
)		/ 0
;		0 1
values

 
.

 
RemoveAt

 
(

 
$num

 
)

 
;

 
foreach 
( 
IList 
< 
object !
>! "
value# (
in) +
values, 2
)2 3
{ 

ReportData 

reportData %
=& '
new( +
(+ ,
), -
{ 
Location 
= 
value $
[$ %
$num% &
]& '
.' (
ToString( 0
(0 1
)1 2
,2 3
ContactCount  
=! "
value# (
[( )
$num) *
]* +
.+ ,
ToString, 4
(4 5
)5 6
,6 7
PhoneNumberCount $
=% &
value' ,
[, -
$num- .
]. /
./ 0
ToString0 8
(8 9
)9 :
} 
; 
reportDatas 
. 
Add 
(  

reportData  *
)* +
;+ ,
} 
return 
reportDatas 
; 
} 	
public 
static 
IList 
< 
IList !
<! "
object" (
>( )
>) *
MapToRangeData+ 9
(9 :

ReportData: D

reportDataE O
)O P
{ 	
List 
< 
object 
> 

objectList #
=$ %
new& )
() *
)* +
{, -

reportData. 8
.8 9
Location9 A
,A B

reportDataC M
.M N
ContactCountN Z
,Z [

reportData\ f
.f g
PhoneNumberCountg w
}x y
;y z
List 
< 
IList 
< 
object 
> 
> 
	rangeData  )
=* +
new, /
(/ 0
)0 1
{2 3

objectList4 >
}? @
;@ A
return 
	rangeData 
; 
} 	
public 
static 
IList 
< 
IList !
<! "
object" (
>( )
>) *
MapToRangeData+ 9
(9 :
List: >
<> ?

ReportData? I
>I J

reportDataK U
)U V
{ 	
List   
<   
object   
>   

objectList   #
=  $ %
new  & )
(  ) *
)  * +
{  , -
$str  . 8
,  8 9
$str  : I
,  I J
$str  K ^
}  _ `
;  ` a
List!! 
<!! 
IList!! 
<!! 
object!! 
>!! 
>!! 
	rangeData!!  )
=!!* +
new!!, /
(!!/ 0
)!!0 1
{!!2 3

objectList!!4 >
}!!? @
;!!@ A
foreach"" 
("" 

ReportData"" 
data""  $
in""% '

reportData""( 2
)""2 3
{## 
	rangeData$$ 
.$$ 
Add$$ 
($$ 
new$$ !
List$$" &
<$$& '
object$$' -
>$$- .
($$. /
)$$/ 0
{$$1 2
data$$3 7
.$$7 8
Location$$8 @
,$$@ A
data$$B F
.$$F G
ContactCount$$G S
,$$S T
data$$U Y
.$$Y Z
PhoneNumberCount$$Z j
}$$k l
)$$l m
;$$m n
}%% 
return&& 
	rangeData&& 
;&& 
}'' 	
}(( 
})) í
iC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Models\GetContactsResponseModel.cs
	namespace 	
Report
 
. 
API 
. 
Models 
{ 
public 

class $
GetContactsResponseModel )
{ 
public 
string 
Id 
{ 
get 
; 
set  #
;# $
}% &
public 
string 
	FirstName 
{  !
get" %
;% &
set' *
;* +
}, -
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
public		 
string		 
Company		 
{		 
get		  #
;		# $
set		% (
;		( )
}		* +
public

 
List

 
<

 
CommunicationInfo

 %
>

% &
CommunicationInfo

' 8
{

9 :
get

; >
;

> ?
set

@ C
;

C D
}

E F
} 
public 

class 
CommunicationInfo "
{ 
public 
CommunationInfoType "
InfoType# +
{, -
get. 1
;1 2
set3 6
;6 7
}8 9
public 
string 
Detail 
{ 
get "
;" #
set$ '
;' (
}) *
} 
public 

enum 
CommunationInfoType #
{ 
PhoneNumber 
, 
Email 
, 
Location 
} 
} Ñ$
QC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Program.cs
var

 
builder

 
=

 
WebApplication

 
.

 
CreateBuilder

 *
(

* +
args

+ /
)

/ 0
;

0 1
builder 
. 
Services 
. #
AddEndpointsApiExplorer (
(( )
)) *
;* +
builder 
. 
Services 
. 
AddSwaggerGen 
( 
)  
;  !
builder 
. 
Services 
. 
AddSingleton 
< 
IReportContext ,
,, -
ReportContext. ;
>; <
(< =
)= >
;> ?
builder 
. 
Services 
. 
AddHttpClient 
( 
)  
;  !
builder 
. 
Services 
. 
AddTransient 
( 
typeof $
($ %
GoogleSheetsHelper% 7
)7 8
)8 9
;9 :
builder 
. 
Services 
. 
AddTransient 
< 
IGoogleSheetService 1
,1 2
GoogleSheetService3 E
>E F
(F G
)G H
;H I
builder 
. 
Services 
. 
AddTransient 
< 
IContactService -
,- .
ContactService/ =
>= >
(> ?
)? @
;@ A
builder 
. 
Services 
. 
AddTransient 
< 
IReportService ,
,, -
ReportService. ;
>; <
(< =
)= >
;> ?
builder 
. 
Services 
. 
AddSingleton 
< 
IReportRepository /
,/ 0
ReportRepository1 A
>A B
(B C
)C D
;D E
builder 
. 
Services 
. 
AddMassTransit 
(  
config  &
=>' )
{ 
config 

.
 
AddConsumer 
<  
ReportCreateConsumer +
>+ ,
(, -
)- .
;. /
config 

.
 
UsingRabbitMq 
( 
( 
ctx 
, 
cfg "
)" #
=>$ &
{ 
cfg 
. 
Host 
( 
$str 
, 
hostConfigurator -
=>. 0
{1 2
}3 4
)4 5
;5 6
cfg   
.   
ReceiveEndpoint   
(   
EventBusConstants   -
.  - .
ReportCreateQueue  . ?
,  ? @
c  A B
=>  C E
{!! 	
c"" 
."" 
ConfigureConsumer"" 
<""   
ReportCreateConsumer""  4
>""4 5
(""5 6
ctx""6 9
)""9 :
;"": ;
}## 	
)##	 

;##
 
}$$ 
)$$ 
;$$ 
}%% 
)%% 
;%% 
builder'' 
.'' 
Services'' 
.'' 
	AddScoped'' 
<''  
ReportCreateConsumer'' /
>''/ 0
(''0 1
)''1 2
;''2 3
builder)) 
.)) 
Services)) 
.)) 
AddControllers)) 
())  
)))  !
;))! "
var,, 
app,, 
=,, 	
builder,,
 
.,, 
Build,, 
(,, 
),, 
;,, 
if// 
(// 
app// 
.// 
Environment// 
.// 
IsDevelopment// !
(//! "
)//" #
)//# $
{00 
app11 
.11 

UseSwagger11 
(11 
)11 
;11 
app22 
.22 
UseSwaggerUI22 
(22 
)22 
;22 
}33 
app55 
.55 
UseAuthorization55 
(55 
)55 
;55 
app77 
.77 
MapControllers77 
(77 
)77 
;77 
app99 
.99 
Run99 
(99 
)99 	
;99	 
◊
fC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Repository\IReportRepository.cs
	namespace 	
Report
 
. 
API 
. 

Repository 
{ 
public 

	interface 
IReportRepository &
{ 
Task 
< 
List 
< 
ReportResult 
> 
>  
GetAsync! )
() *
)* +
;+ ,
Task 
< 
ReportResult 
? 
> 
GetAsync $
($ %
string% +
id, .
). /
;/ 0
Task		 
<		 
ReportResult		 
>		 
CreateAsync		 &
(		& '
ReportResult		' 3
reportResult		4 @
)		@ A
;		A B
Task

 
<

 
bool

 
>

 
UpdateAsync

 
(

 
ReportResult

 +
reportResult

, 8
)

8 9
;

9 :
} 
} ¨
eC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Repository\ReportRepository.cs
	namespace 	
Report
 
. 
API 
. 

Repository 
{ 
public 

class 
ReportRepository !
:" #
IReportRepository$ 5
{ 
private		 
readonly		 
IReportContext		 '
_context		( 0
;		0 1
public 
ReportRepository 
(  
IReportContext  .
context/ 6
)6 7
{ 	
_context 
= 
context 
; 
} 	
public 
async 
Task 
< 
List 
< 
ReportResult +
>+ ,
>, -
GetAsync. 6
(6 7
)7 8
{ 	
return 
await 
_context !
.! "
ReportResults" /
./ 0
Find0 4
(4 5
_5 6
=>7 9
true: >
)> ?
.? @
ToListAsync@ K
(K L
)L M
;M N
} 	
public 
async 
Task 
< 
ReportResult &
?& '
>' (
GetAsync) 1
(1 2
string2 8
id9 ;
); <
{ 	
return 
await 
_context !
.! "
ReportResults" /
./ 0
Find0 4
(4 5
x5 6
=>7 9
x: ;
.; <
Id< >
==? A
idB D
)D E
.E F
FirstOrDefaultAsyncF Y
(Y Z
)Z [
;[ \
} 	
public 
async 
Task 
< 
ReportResult &
>& '
CreateAsync( 3
(3 4
ReportResult4 @
reportResultA M
)M N
{ 	
await 
_context 
. 
ReportResults (
.( )
InsertOneAsync) 7
(7 8
reportResult8 D
)D E
;E F
return 
reportResult 
;  
}!! 	
public## 
async## 
Task## 
<## 
bool## 
>## 
UpdateAsync##  +
(##+ ,
ReportResult##, 8
reportResult##9 E
)##E F
{$$ 	
ReplaceOneResult%% 
updateResult%% )
=%%* +
await%%, 1
_context%%2 :
.%%: ;
ReportResults%%; H
.%%H I
ReplaceOneAsync%%I X
(%%X Y
filter%%Y _
:%%_ `
g%%a b
=>%%c e
g%%f g
.%%g h
Id%%h j
==%%k m
reportResult%%n z
.%%z {
Id%%{ }
,%%} ~
replacement	%% ä
:
%%ä ã
reportResult
%%å ò
)
%%ò ô
;
%%ô ö
return'' 
updateResult'' 
.''  
IsAcknowledged''  .
&&(( 
updateResult(( #
.((# $
ModifiedCount(($ 1
>((2 3
$num((4 5
;((5 6
})) 	
}** 
}++ π
`C:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Service\ContactService.cs
	namespace 	
Report
 
. 
API 
. 
Service 
{ 
public 

class 
ContactService 
:  !
IContactService" 1
{		 
private

 
readonly

 

HttpClient

 #
_httpClient

$ /
;

/ 0
public 
ContactService 
( 

HttpClient (

httpClient) 3
)3 4
{ 	
_httpClient 
= 

httpClient $
;$ %
_httpClient 
. 
BaseAddress #
=$ %
new& )
Uri* -
(- .
$str. Q
)Q R
;R S
} 	
public 
async 
Task 
< 
List 
< $
GetContactsResponseModel 7
?7 8
>8 9
>9 :
GetData; B
(B C
)C D
{ 	
return 
await 
_httpClient $
.$ %
GetFromJsonAsync% 5
<5 6
List6 :
<: ;$
GetContactsResponseModel; S
?S T
>T U
>U V
(V W
$strW d
)d e
;e f
} 	
} 
} ∂%
dC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Service\GoogleSheetService.cs
	namespace 	
Report
 
. 
API 
. 
Service 
{ 
public		 

class		 
GoogleSheetService		 #
:		$ %
IGoogleSheetService		& 9
{

 
private 
const 
string 
SPREADSHEET_ID +
=, -
$str. \
;\ ]
private 
readonly  
SpreadsheetsResource -
_googleSheetService. A
;A B
public 
GoogleSheetService !
(! "
GoogleSheetsHelper" 4
googleSheetsHelper5 G
)G H
{ 	
_googleSheetService 
=  !
googleSheetsHelper" 4
.4 5
Service5 <
.< =
Spreadsheets= I
;I J
} 	
public 
async 
Task 
< 
string  
>  !
AddDatas" *
(* +
List+ /
</ 0

ReportData0 :
>: ;
reports< C
)C D
{ 	*
BatchUpdateSpreadsheetResponse *
newSheet+ 3
=4 5
await6 ;
CreateNewSheet< J
(J K
)K L
;L M
string 
title 
= 
newSheet #
?# $
.$ %
Replies% ,
?, -
.- .
FirstOrDefault. <
(< =
)= >
.> ?
AddSheet? G
.G H

PropertiesH R
.R S
TitleS X
;X Y
string 
range 
= 
$" 
{ 
title #
}# $
$str$ (
"( )
;) *
List 
< 

ValueRange 
> 

valueRange '
=( )
new* -
(- .
). /
{ 
new 

ValueRange 
( 
)  
{ 
Values 
= 
ReportMapper *
.* +
MapToRangeData+ 9
(9 :
reports: A
)A B
,B C
Range 
= 
range "
," #
MajorDimension #
=$ %
$str& ,
}   
}"" 
;"" $
BatchUpdateValuesRequest## $
body##% )
=##* +
new##, /
(##/ 0
)##0 1
{$$ 
ValueInputOption%%  
=%%! "
$str%%# 1
,%%1 2
Data&& 
=&& 

valueRange&& !
}'' 
;'' 
await)) 
_googleSheetService)) %
.))% &
Values))& ,
.)), -
BatchUpdate))- 8
())8 9
body))9 =
,))> ?
SPREADSHEET_ID))@ N
)))N O
.))O P
ExecuteAsync))P \
())\ ]
)))] ^
;))^ _
return++ 
title++ 
;++ 
},, 	
private.. 
async.. 
Task.. 
<.. *
BatchUpdateSpreadsheetResponse.. 9
>..9 :
CreateNewSheet..; I
(..I J
)..J K
{// 	)
BatchUpdateSpreadsheetRequest11 )
body11* .
=11/ 0
new111 4
(114 5
)115 6
;116 7
Request33 
bodyItem33 
=33 
new33 "
(33" #
)33# $
{44 
AddSheet55 
=55 
new55 
AddSheetRequest55 .
{66 

Properties77 
=77  
new77! $
SheetProperties77% 4
{88 
Title88 
=88 
$"88  
{88  !
DateTime88! )
.88) *
UtcNow88* 0
.880 1
AddHours881 9
(889 :
$num88: ;
)88; <
}88< =
$str88= E
"88E F
}88G H
}99 
}:: 
;:: 
body;; 
.;; 
Requests;; 
=;; 
new;; 
Request;;  '
[;;' (
];;( )
{;;* +
bodyItem;;, 4
};;5 6
;;;6 7
var== 
request== 
=== 
_googleSheetService== -
.==- .
BatchUpdate==. 9
(==9 :
body==: >
,==> ?
SPREADSHEET_ID==@ N
)==N O
;==O P
return?? 
await?? 
request??  
.??  !
ExecuteAsync??! -
(??- .
)??. /
;??/ 0
}@@ 	
}DD 
}EE Ÿ
lC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Service\Interfaces\IContactService.cs
	namespace 	
Report
 
. 
API 
. 
Service 
. 

Interfaces '
{ 
public 

	interface 
IContactService $
{ 
Task 
< 
List 
< $
GetContactsResponseModel *
?* +
>+ ,
>, -
GetData. 5
(5 6
)6 7
;7 8
}		 
}

 Ó
pC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Service\Interfaces\IGoogleSheetService.cs
	namespace 	
Report
 
. 
API 
. 
Service 
. 

Interfaces '
{ 
public 

	interface 
IGoogleSheetService (
{ 
Task 
< 
string 
> 
AddDatas 
( 
List "
<" #

ReportData# -
>- .
reports/ 6
)6 7
;7 8
}

 
} Í
kC:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Service\Interfaces\IReportService.cs
	namespace 	
Report
 
. 
API 
. 
Service 
. 

Interfaces '
{ 
public 

	interface 
IReportService #
{ 
Task		 
CreateReportRequest		  
(		  !
)		! "
;		" #
Task

 
CreateReport

 
(

 
ReportCreateEvent

 +
context

, 3
)

3 4
;

4 5
Task 
< 
List 
< 
ReportResult 
> 
>  
GetAsync! )
() *
)* +
;+ ,
Task 
< 
ReportResult 
? 
> 
GetAsync $
($ %
string% +
id, .
). /
;/ 0
} 
} æN
`C:\Users\Asya\source\repos\contacts-app\src\Services\Report\Report.API\Service\ReportService .cs
	namespace

 	
Report


 
.

 
API

 
.

 
Service

 
{ 
public 

class 
ReportService 
:  
IReportService! /
{ 
private 
readonly 
IReportRepository *
_reportRepository+ <
;< =
private 
readonly 
IContactService (
_contactService) 8
;8 9
private 
readonly 
IGoogleSheetService ,
_googleService- ;
;; <
private 
readonly 
IPublishEndpoint )
_publishEndpoint* :
;: ;
private 
const 
string 
URL  
=! "
$str	# Ñ
;
Ñ Ö
public 
ReportService 
( 
IReportRepository .
reportRepository/ ?
,? @
IContactService ,
contactService- ;
,; <
IGoogleSheetService 0
googleService1 >
,> ?
IPublishEndpoint -
publishEndpoint. =
)= >
{ 	
_reportRepository 
= 
reportRepository  0
;0 1
_contactService 
= 
contactService ,
;, -
_googleService 
= 
googleService *
;* +
_publishEndpoint 
= 
publishEndpoint .
;. /
} 	
public 
async 
Task 
CreateReportRequest -
(- .
). /
{ 	
ReportResult   
report   
=    !
await  " '
AddReportResult  ( 7
(  7 8
)  8 9
;  9 :
List"" 
<"" $
GetContactsResponseModel"" )
>"") *
contacts""+ 3
=""4 5
await""6 ;
_contactService""< K
.""K L
GetData""L S
(""S T
)""T U
;""U V
await$$ 
_publishEndpoint$$ "
.$$" #
Publish$$# *
<$$* +
ReportCreateEvent$$+ <
>$$< =
($$= >
new$$> A
ReportCreateEvent$$B S
{%% 
Contacts&& 
=&& 
contacts&& #
,&&# $
Report'' 
='' 
report'' 
,''  
}(( 
)(( 
;(( 
}** 	
public++ 
Task++ 
<++ 
List++ 
<++ 
ReportResult++ %
>++% &
>++& '
GetAsync++( 0
(++0 1
)++1 2
{,, 	
return-- 
_reportRepository-- $
.--$ %
GetAsync--% -
(--- .
)--. /
;--/ 0
}.. 	
public00 
Task00 
<00 
ReportResult00  
?00  !
>00! "
GetAsync00# +
(00+ ,
string00, 2
id003 5
)005 6
{11 	
return22 
_reportRepository22 $
.22$ %
GetAsync22% -
(22- .
id22. 0
)220 1
;221 2
}33 	
public66 
async66 
Task66 
CreateReport66 &
(66& '
ReportCreateEvent66' 8
context669 @
)66@ A
{77 	
List88 
<88 

ReportData88 
>88 
data88 !
=88" #
PrepareDatas88$ 0
(880 1
context881 8
.888 9
Contacts889 A
)88A B
;88B C
string:: 
title:: 
=:: 
await::  
_googleService::! /
.::/ 0
AddDatas::0 8
(::8 9
data::9 =
)::= >
;::> ?
context<< 
.<< 
Report<< 
.<< 
	ReportUrl<< $
=<<% &
URL<<' *
;<<* +
context== 
.== 
Report== 
.== 
Title==  
===! "
title==# (
;==( )
context>> 
.>> 
Report>> 
.>> 
Status>> !
=>>" #
Status>>$ *
.>>* +
Done>>+ /
;>>/ 0
context?? 
.?? 
Report?? 
.?? 
CreatedDate?? &
=??' (
context??) 0
.??0 1
CreationDate??1 =
.??= >
AddHours??> F
(??F G
$num??G H
)??H I
;??I J
context@@ 
.@@ 
Report@@ 
.@@ 
QueueId@@ "
=@@# $
context@@% ,
.@@, -
Id@@- /
.@@/ 0
ToString@@0 8
(@@8 9
)@@9 :
;@@: ;
awaitBB 
UpdateReportResultBB $
(BB$ %
contextBB% ,
.BB, -
ReportBB- 3
)BB3 4
;BB4 5
}CC 	
privateEE 
staticEE 
ListEE 
<EE 

ReportDataEE &
>EE& '
PrepareDatasEE( 4
(EE4 5
ListEE5 9
<EE9 :$
GetContactsResponseModelEE: R
>EER S
contactResponseListEET g
)EEg h
{FF 	
ListGG 
<GG 

ReportDataGG 
>GG 
responseListGG )
=GG* +
newGG, /
(GG/ 0
)GG0 1
;GG1 2
foreachHH 
(HH 
varHH 
infoHH 
inHH  
contactResponseListHH! 4
.HH4 5
SelectHH5 ;
(HH; <
xHH< =
=>HH> @
xHHA B
.HHB C
CommunicationInfoHHC T
)HHT U
)HHU V
{II 
varJJ 
itemJJ 
=JJ 
responseListJJ '
.JJ' (
	FindIndexJJ( 1
(JJ1 2
xJJ2 3
=>JJ4 6
xJJ7 8
.JJ8 9
LocationJJ9 A
==JJB D
infoJJE I
.JJI J
FirstOrDefaultJJJ X
(JJX Y
xJJY Z
=>JJ[ ]
xJJ^ _
.JJ_ `
InfoTypeJJ` h
==JJi k
CommunationInfoTypeJJl 
.	JJ Ä
Location
JJÄ à
)
JJà â
?
JJâ ä
.
JJä ã
Detail
JJã ë
)
JJë í
;
JJí ì
ifKK 
(KK 
itemKK 
!=KK 
-KK 
$numKK 
)KK 
{LL 
responseListNN  
[NN  !
itemNN! %
]NN% &
.NN& '
ContactCountNN' 3
=NN4 5
(NN6 7
ConvertNN7 >
.NN> ?
ToInt32NN? F
(NNF G
responseListNNG S
[NNS T
itemNNT X
]NNX Y
.NNY Z
ContactCountNNZ f
)NNf g
+NNh i
$numNNj k
)NNk l
.NNl m
ToStringNNm u
(NNu v
)NNv w
;NNw x
responseListOO  
[OO  !
itemOO! %
]OO% &
.OO& '
PhoneNumberCountOO' 7
=OO8 9
infoOO: >
.OO> ?
AnyOO? B
(OOB C
xOOC D
=>OOE G
xOOH I
.OOI J
InfoTypeOOJ R
==OOS U
CommunationInfoTypeOOV i
.OOi j
PhoneNumberOOj u
)OOu v
?OOw x
(PP 
ConvertPP  
.PP  !
ToInt32PP! (
(PP( )
responseListPP) 5
[PP5 6
itemPP6 :
]PP: ;
.PP; <
PhoneNumberCountPP< L
)PPL M
+PPN O
$numPPP Q
)PPQ R
.PPR S
ToStringPPS [
(PP[ \
)PP\ ]
:PP^ _
responseListPP` l
[PPl m
itemPPm q
]PPq r
.PPr s
PhoneNumberCount	PPs É
;
PPÉ Ñ
}RR 
elseSS 
{TT 
responseListUU  
.UU  !
AddUU! $
(UU$ %
newUU% (

ReportDataUU) 3
{VV 
ContactCountWW $
=WW% &
$strWW' *
,WW* +
LocationXX  
=XX! "
infoXX# '
.XX' (
FirstOrDefaultXX( 6
(XX6 7
xXX7 8
=>XX9 ;
xXX< =
.XX= >
InfoTypeXX> F
==XXG I
CommunationInfoTypeXXJ ]
.XX] ^
LocationXX^ f
)XXf g
.XXg h
DetailXXh n
,XXn o
PhoneNumberCountYY (
=YY) *
infoYY+ /
.YY/ 0
AnyYY0 3
(YY3 4
xYY4 5
=>YY6 8
xYY9 :
.YY: ;
InfoTypeYY; C
==YYD F
CommunationInfoTypeYYG Z
.YYZ [
PhoneNumberYY[ f
)YYf g
?YYh i
$strYYj m
:YYn o
$strYYp s
,YYs t
}ZZ 
)ZZ 
;ZZ 
}\\ 
}]] 
return^^ 
responseList^^ 
;^^  
}`` 	
privatebb 
asyncbb 
Taskbb 
UpdateReportResultbb -
(bb- .
ReportResultbb. :
resultbb; A
)bbA B
{cc 	
awaitdd 
_reportRepositorydd #
.dd# $
UpdateAsyncdd$ /
(dd/ 0
resultdd0 6
)dd6 7
;dd7 8
}ee 	
privateff 
asyncff 
Taskff 
<ff 
ReportResultff '
>ff' (
AddReportResultff) 8
(ff8 9
)ff9 :
{gg 	
returnii 
awaitii 
_reportRepositoryii *
.ii* +
CreateAsyncii+ 6
(ii6 7
newii7 :
ReportResultii; G
{jj 
Statuskk 
=kk 
Statuskk 
.kk  

Prepraringkk  *
,kk* +
}ll 
)ll 
;ll 
}mm 	
}nn 
}oo 