�5
qC:\Users\Asya\source\repos\contacts-app\src\Services\ContactBook\ContactBook.API\Controllers\ContactController.cs
	namespace 	
ContactBook
 
. 
API 
. 
Controllers %
{ 
[ 

] 
[		 
Route		 

(		
 
$str		 
)		 
]		 
public

 

class

 
ContactController

 "
:

# $
ControllerBase

% 3
{ 
private 
readonly 
IContactRepository +
_repository, 7
;7 8
public 
ContactController  
(  !
IContactRepository! 3

repository4 >
)> ?
{ 	
_repository 
= 

repository $
;$ %
} 	
[ 	
HttpGet	 
] 
[ 	 
ProducesResponseType	 
( 
typeof $
($ %
IEnumerable% 0
<0 1
Contact1 8
>8 9
)9 :
,: ;
(< =
int= @
)@ A
HttpStatusCodeA O
.O P
OKP R
)R S
]S T
public 
async 
Task 
< 
ActionResult &
<& '
IEnumerable' 2
<2 3
Contact3 :
>: ;
>; <
>< =
Get> A
(A B
)B C
{ 	
var 
contacts 
= 
await  
_repository! ,
., -
GetAsync- 5
(5 6
)6 7
;7 8
return 
Ok 
( 
contacts 
) 
;  
} 	
[ 	
HttpGet	 
( 
$str 
, 
Name 
= 
$str  ,
), -
]- .
public 
async 
Task 
< 
ActionResult &
<& '
Contact' .
>. /
>/ 0
Get1 4
(4 5
string5 ;
id< >
)> ?
{   	
Contact!! 
?!! 
contact!! 
=!! 
await!! $
_repository!!% 0
.!!0 1
GetAsync!!1 9
(!!9 :
id!!: <
)!!< =
;!!= >
return## 
contact## 
is## 
null## "
?### $
(##% &
ActionResult##& 2
<##2 3
Contact##3 :
>##: ;
)##; <
NotFound##< D
(##D E
)##E F
:##G H
(##I J
ActionResult##J V
<##V W
Contact##W ^
>##^ _
)##_ `
Ok##` b
(##b c
contact##c j
)##j k
;##k l
}$$ 	
[&& 	
HttpPost&&	 
]&& 
public'' 
async'' 
Task'' 
<'' 
ActionResult'' &
>''& '
Create''( .
(''. /
Contact''/ 6
contact''7 >
)''> ?
{(( 	
if)) 
()) 
!)) 

ModelState)) 
.)) 
IsValid)) #
)))# $
{** 
return++ 

BadRequest++ !
(++! "

ModelState++" ,
)++, -
;++- .
},, 
await-- 
_repository-- 
.-- 
CreateAsync-- )
(--) *
contact--* 1
)--1 2
;--2 3
return// 
CreatedAtAction// "
(//" #
nameof//# )
(//) *
Get//* -
)//- .
,//. /
new//0 3
{//4 5
id//6 8
=//9 :
contact//; B
.//B C
Id//C E
}//F G
,//G H
contact//I P
)//P Q
;//Q R
}00 	
[22 	

HttpDelete22	 
]22 
public33 
async33 
Task33 
<33 
ActionResult33 &
>33& '
Delete33( .
(33. /
string33/ 5
id336 8
)338 9
{44 	
Contact55 
?55 
book55 
=55 
await55 !
_repository55" -
.55- .
GetAsync55. 6
(556 7
id557 9
)559 :
;55: ;
if77 
(77 
book77 
is77 
null77 
)77 
{88 
return99 
NotFound99 
(99  
)99  !
;99! "
}:: 
await<< 
_repository<< 
.<< 
DeleteAsync<< )
(<<) *
id<<* ,
)<<, -
;<<- .
return>> 
	NoContent>> 
(>> 
)>> 
;>> 
}?? 	
[AA 	
HttpPutAA	 
]AA 
[BB 	
RouteBB	 
(BB 
$strBB 
)BB 
]BB  
publicCC 
asyncCC 
TaskCC 
<CC 
ActionResultCC &
>CC& '
AddContactInfoCC( 6
(CC6 7
stringCC7 =
idCC> @
,CC@ A
[CCB C
FromBodyCCC K
]CCK L
CommunicationInfoCCM ^
contactInfoCC_ j
)CCj k
{DD 	
ifEE 
(EE 
!EE 

ModelStateEE 
.EE 
IsValidEE #
)EE# $
{FF 
returnGG 

BadRequestGG !
(GG! "

ModelStateGG" ,
)GG, -
;GG- .
}HH 
boolII 
resultII 
=II 
awaitII 
_repositoryII  +
.II+ ,
AddContactInfoAsyncII, ?
(II? @
idII@ B
,IIB C
contactInfoIID O
)IIO P
;IIP Q
returnKK 
resultKK 
?KK 
	NoContentKK %
(KK% &
)KK& '
:KK( )

BadRequestKK* 4
(KK4 5
$strKK5 d
)KKd e
;KKe f
}MM 	
[OO 	
HttpPutOO	 
]OO 
[PP 	
RoutePP	 
(PP 
$strPP 
)PP 
]PP  
publicQQ 
asyncQQ 
TaskQQ 
<QQ 
ActionResultQQ &
>QQ& '
DeleteContactInfoQQ( 9
(QQ9 :
stringQQ: @
idQQA C
)QQC D
{RR 	
awaitSS 
_repositorySS 
.SS (
DeleteCommunicationInfoAsyncSS :
(SS: ;
idSS; =
)SS= >
;SS> ?
returnUU 
	NoContentUU 
(UU 
)UU 
;UU 
}VV 	
}XX 
}YY �
gC:\Users\Asya\source\repos\contacts-app\src\Services\ContactBook\ContactBook.API\Data\ContactContext.cs
	namespace 	
ContactBook
 
. 
API 
. 
Data 
{ 
public 

class 
ContactContext 
:  !
IContactContext" 1
{ 
public 
ContactContext 
( 
IConfiguration ,

): ;
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

.F G
GetValueG O
<O P
stringP V
>V W
(W X
$strX w
)w x
)x y
;y z
Contacts
=
database
.

<
Contact
>
(

.
GetValue
<
string
>
(
$str
)
)
;
ContactContextSeed 
. 
SeedData '
(' (
Contacts( 0
)0 1
;1 2
} 	
public 
IMongoCollection 
<  
Contact  '
>' (
Contacts) 1
{2 3
get4 7
;7 8
}9 :
} 
} �*
kC:\Users\Asya\source\repos\contacts-app\src\Services\ContactBook\ContactBook.API\Data\ContactContextSeed.cs
	namespace 	
ContactBook
 
. 
API 
. 
Data 
{ 
public 

static 
class 
ContactContextSeed *
{ 
public 
static 
void 
SeedData #
(# $
IMongoCollection$ 4
<4 5
Contact5 <
>< =
contactCollection> O
)O P
{		 	
bool

 
exist

 
=

 
contactCollection

 *
.

* +
Find

+ /
(

/ 0
p

0 1
=>

2 4
true

5 9
)

9 :
.

: ;
Any

; >
(

> ?
)

? @
;

@ A
if 
( 
! 
exist 
) 
{ 
contactCollection
.

InsertMany
(
GetPreconfiguredContacts
(
)
)
;
} 
} 	
private 
static 
IEnumerable "
<" #
Contact# *
>* +$
GetPreconfiguredContacts, D
(D E
)E F
{ 	
return 
new 
List 
< 
Contact #
># $
($ %
)% &
{ 
new 
Contact 
( 
) 
{ 
	FirstName 
= 
$str  &
,& '
LastName 
= 
$str (
,( )
Company 
= 
$str '
,' (
CommunicationInfo %
=& '
new( +
List, 0
<0 1
CommunicationInfo1 B
>B C
{ 
new 
CommunicationInfo -
{ 
Detail "
=# $
$str% -
,- .
InfoType $
=% &
CommunationInfoType' :
.: ;
Location; C
}   
,   
new!! 
CommunicationInfo!! .
{"" 
Detail## "
=### $
$str##% 2
,##2 3
InfoType$$ $
=$$% &
CommunationInfoType$$' :
.$$: ;
PhoneNumber$$; F
}%% 
,%% 
new&& 
CommunicationInfo&& 0
{'' 
Detail(( "
=((# $
$str((% =
,((= >
InfoType)) $
=))% &
CommunationInfoType))' :
.)): ;
Email)); @
}** 
,** 
}++ 
},, 
,,, 
new-- 
Contact-- 
(-- 
)-- 
{.. 
	FirstName// 
=// 
$str//  &
,//& '
LastName00 
=00 
$str00 $
,00$ %
Company11 
=11 
$str11 '
,11' (
CommunicationInfo22 %
=22& '
new22( +
List22, 0
<220 1
CommunicationInfo221 B
>22B C
{33 
new44 
CommunicationInfo44 -
{55 
Detail66 "
=66# $
$str66% -
,66- .
InfoType77 $
=77% &
CommunationInfoType77' :
.77: ;
Location77; C
}88 
,88 
new99 
CommunicationInfo99 .
{:: 
Detail;; "
=;;# $
$str;;% 2
,;;2 3
InfoType<< $
=<<% &
CommunationInfoType<<' :
.<<: ;
PhoneNumber<<; F
}== 
,== 
new>> 
CommunicationInfo>> 0
{?? 
Detail@@ "
=@@# $
$str@@% 8
,@@8 9
InfoTypeAA $
=AA% &
CommunationInfoTypeAA' :
.AA: ;
EmailAA; @
}BB 
,BB 
}CC 
}DD 
,DD 
newEE 
ContactEE 
(EE 
)EE 
{FF 
	FirstNameGG 
=GG 
$strGG  &
,GG& '
LastNameHH 
=HH 
$strHH $
,HH$ %
CompanyII 
=II 
$strII '
,II' (
CommunicationInfoJJ %
=JJ& '
newJJ( +
ListJJ, 0
<JJ0 1
CommunicationInfoJJ1 B
>JJB C
{KK 
newLL 
CommunicationInfoLL -
{MM 
DetailNN "
=NN# $
$strNN% /
,NN/ 0
InfoTypeOO $
=OO% &
CommunationInfoTypeOO' :
.OO: ;
LocationOO; C
}PP 
,PP 
newQQ 
CommunicationInfoQQ .
{RR 
DetailSS "
=SS# $
$strSS% 2
,SS2 3
InfoTypeTT $
=TT% &
CommunationInfoTypeTT' :
.TT: ;
PhoneNumberTT; F
}UU 
,UU 
newVV 
CommunicationInfoVV 0
{WW 
DetailXX "
=XX# $
$strXX% 8
,XX8 9
InfoTypeYY $
=YY% &
CommunationInfoTypeYY' :
.YY: ;
EmailYY; @
}ZZ 
,ZZ 
}[[ 
}\\ 
}^^ 
;^^
}__ 	
}`` 
}aa �
hC:\Users\Asya\source\repos\contacts-app\src\Services\ContactBook\ContactBook.API\Data\IContactContext.cs
	namespace 	
ContactBook
 
. 
API 
. 
Data 
{ 
public 

	interface 
IContactContext $
{ 
IMongoCollection 
< 
Contact  
>  !
Contacts" *
{+ ,
get- 0
;0 1
}2 3
}		 
}

 �
nC:\Users\Asya\source\repos\contacts-app\src\Services\ContactBook\ContactBook.API\Entities\CommunicationInfo.cs
	namespace 	
ContactBook
 
. 
API 
. 
Entities "
{ 
public 

class 
CommunicationInfo "
{ 
[ 	
Required	 
] 
public		 
CommunationInfoType		 "
InfoType		# +
{		, -
get		. 1
;		1 2
set		3 6
;		6 7
}		8 9
[ 	
Required	 
] 
public
string
Detail
{
get
;
set
;
}
} 
public 

enum 
CommunationInfoType #
{ 
PhoneNumber 
, 
Email 
,
Location 
} 
} �
dC:\Users\Asya\source\repos\contacts-app\src\Services\ContactBook\ContactBook.API\Entities\Contact.cs
	namespace 	
ContactBook
 
. 
API 
. 
Entities "
{ 
public 

class 
Contact 
{ 
[		 	
BsonId			 
]		 
[

 	
BsonRepresentation

	 
(

 
BsonType

 $
.

$ %
ObjectId

% -
)

- .
]

. /
public 
string 
Id 
{ 
get 
; 
set  #
;# $
}% &
[ 	
Required	 
] 
public
string
	FirstName
{
get
;
set
;
}
[ 	
Required	 
] 
public 
string 
LastName 
{  
get! $
;$ %
set& )
;) *
}+ ,
[ 	
Required	 
] 
public 
string 
Company 
{ 
get  #
;# $
set% (
;( )
}* +
public 
List 
< 
CommunicationInfo %
>% &
CommunicationInfo' 8
{9 :
get; >
;> ?
set@ C
;C D
}E F
} 
} �
[C:\Users\Asya\source\repos\contacts-app\src\Services\ContactBook\ContactBook.API\Program.cs
var 
builder 
= 
WebApplication 
. 

(* +
args+ /
)/ 0
;0 1
builder 
. 
Services 
. 
AddControllers 
(  
)  !
;! "
builder

 
.

 
Services

 
.

 #
AddEndpointsApiExplorer

 (
(

( )
)

) *
;

* +
builder 
. 
Services 
. 

( 
)  
;  !
builder 
. 
Services 
. 
AddSingleton 
< 
IContactContext -
,- .
ContactContext/ =
>= >
(> ?
)? @
;@ A
builder 
. 
Services 
. 
AddSingleton 
< 
IContactRepository 0
,0 1
ContactRepository2 C
>C D
(D E
)E F
;F G
var 
app 
= 	
builder
 
. 
Build 
( 
) 
; 
if 
( 
app 
. 
Environment 
. 

(! "
)" #
)# $
{ 
app 
. 

UseSwagger 
( 
) 
; 
app 
. 
UseSwaggerUI 
( 
) 
; 
} 
app 
. 
UseAuthorization 
( 
) 
; 
app 
. 
MapControllers 
( 
) 
; 
app 
. 
Run 
( 
) 	
;	 
�,
rC:\Users\Asya\source\repos\contacts-app\src\Services\ContactBook\ContactBook.API\Repositories\ContactRepository.cs
	namespace 	
ContactBook
 
. 
API 
. 
Repositories &
{ 
public 

class 
ContactRepository "
:# $
IContactRepository% 7
{ 
private		 
readonly		 
IContactContext		 (
_context		) 1
;		1 2
public 
ContactRepository  
(  !
IContactContext! 0
context1 8
)8 9
{
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
< 
Contact &
>& '
>' (
GetAsync) 1
(1 2
)2 3
{ 	
return 
await 
_context !
.! "
Contacts" *
.* +
Find+ /
(/ 0
_0 1
=>2 4
true5 9
)9 :
.: ;
ToListAsync; F
(F G
)G H
;H I
} 	
public 
async 
Task 
< 
Contact !
?! "
>" #
GetAsync$ ,
(, -
string- 3
id4 6
)6 7
{ 	
return 
await 
_context !
.! "
Contacts" *
.* +
Find+ /
(/ 0
x0 1
=>2 4
x5 6
.6 7
Id7 9
==: <
id= ?
)? @
.@ A
FirstOrDefaultAsyncA T
(T U
)U V
;V W
} 	
public 
async 
Task 
CreateAsync %
(% &
Contact& -
contact. 5
)5 6
{ 	
await 
_context 
. 
Contacts #
.# $
InsertOneAsync$ 2
(2 3
contact3 :
): ;
;; <
} 	
public!! 
async!! 
Task!! 
DeleteAsync!! %
(!!% &
string!!& ,
id!!- /
)!!/ 0
{"" 	
await## 
_context## 
.## 
Contacts## #
.### $
DeleteOneAsync##$ 2
(##2 3
x##3 4
=>##5 7
x##8 9
.##9 :
Id##: <
==##= ?
id##@ B
)##B C
;##C D
}$$ 	
public&& 
async&& 
Task&& 
<&& 
bool&& 
>&& 
AddContactInfoAsync&&  3
(&&3 4
string&&4 :
id&&; =
,&&= >
CommunicationInfo&&? P
contactInfo&&Q \
)&&\ ]
{'' 	
Contact(( 
contact(( 
=(( 
_context(( &
.((& '
Contacts((' /
.((/ 0
Find((0 4
(((4 5
p((5 6
=>((7 9
p((: ;
.((; <
Id((< >
==((? A
id((B D
)((D E
.((E F
Single((F L
(((L M
)((M N
;((N O
if** 
(** 
contactInfo** 
!=** 
null** #
&&**$ &
contact**' .
!=**/ 1
null**2 6
&&**7 9
!**: ;
contact**; B
.**B C
CommunicationInfo**C T
.**T U
Any**U X
(**X Y
x**Y Z
=>**[ ]
x**^ _
.**_ `
InfoType**` h
==**i k
contactInfo**l w
.**w x
InfoType	**x �
)
**� �
)
**� �
{++ 
contact,, 
.,, 
CommunicationInfo,, )
.,,) *
Add,,* -
(,,- .
contactInfo,,. 9
),,9 :
;,,: ;
await-- 
_context-- 
.-- 
Contacts-- '
.--' (
ReplaceOneAsync--( 7
(--7 8
p--8 9
=>--: <
p--= >
.--> ?
Id--? A
==--B D
id--E G
,--G H
contact--I P
)--P Q
;--Q R
return.. 
true.. 
;.. 
}00 
return11 
false11 
;11 
}33 	
public55 
async55 
Task55 (
DeleteCommunicationInfoAsync55 6
(556 7
string557 =
id55> @
)55@ A
{66 	
Contact77 
contact77 
=77 
_context77 &
.77& '
Contacts77' /
.77/ 0
Find770 4
(774 5
p775 6
=>777 9
p77: ;
.77; <
Id77< >
==77? A
id77B D
)77D E
.77E F
Single77F L
(77L M
)77M N
;77N O
if99 
(99 
contact99 
!=99 
null99 
)99  
{:: 
contact;; 
.;; 
CommunicationInfo;; )
.;;) *
Clear;;* /
(;;/ 0
);;0 1
;;;1 2
await== 
_context== 
.== 
Contacts== '
.==' (
ReplaceOneAsync==( 7
(==7 8
p==8 9
=>==: <
p=== >
.==> ?
Id==? A
====B D
id==E G
,==G H
contact==I P
)==P Q
;==Q R
}?? 
}@@ 	
}CC 
}DD �

sC:\Users\Asya\source\repos\contacts-app\src\Services\ContactBook\ContactBook.API\Repositories\IContactRepository.cs
	namespace 	
ContactBook
 
. 
API 
. 
Repositories &
{ 
public 

	interface 
IContactRepository '
{ 
Task 
CreateAsync
( 
Contact  
contact! (
)( )
;) *
Task 
DeleteAsync
( 
string 
id  "
)" #
;# $
Task 
< 
bool
> 
AddContactInfoAsync &
(& '
string' -
id. 0
,0 1
CommunicationInfo2 C
contactInfoD O
)O P
;P Q
Task (
DeleteCommunicationInfoAsync
() *
string* 0
id1 3
)3 4
;4 5
Task 
< 
List
< 
Contact 
> 
> 
GetAsync $
($ %
)% &
;& '
Task 
< 
Contact
? 
> 
GetAsync 
(  
string  &
id' )
)) *
;* +
} 
} 