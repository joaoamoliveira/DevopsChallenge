Param
  (
     [parameter(Position=0, Mandatory=$true)]
     [String]
     $VersionA,
     [parameter(Position=1, Mandatory=$true)]
     [String]
     $VersionB
  ) 

$input1 = $VersionA
$input2 = $VersionB

$val1 = $input1.Split("-")
$val2 = $input2.Split("-")
$release1string = $val1[0].Split(".")
[array]$release1 = foreach($number in $release1string) {([int]::parse($number))}
$release2string = $val2[0].Split(".")
[array]$release2 = foreach($number in $release2string) {([int]::parse($number))}
$preRelease1 = $val1[1]
$preRelease2 = $val2[1]

$i = 0
while($i -lt $release1.Length -and $i -lt $release2.Length -and $release1[$i].Equals($release2[$i]))
{ $i++ }
if($release1[$i] -gt $release2[$i]) <# release1 > release2 #>
{
    $version = $input1
}
elseif($release1[$i] -lt $release2[$i]) <# release1 < release2 #>
{
    $version = $input2
}
else <# release1 == release2 #>
{
    if($preRelease1 -eq $null -and $preRelease2 -eq $null -or <# preRelease1 == null && preRelease2 == null #>
       $preRelease1 -eq $null -and $preRelease2 -ne $null)    <# preRelease1 == null && preRelease2 != null #>
    {
        $version = $input1
    }
    elseif($preRelease1 -ne $null -and $preRelease2 -eq $null) <# preRelease1 != null && preRelease2 == null #>
    {
        $version = $input2
    }
    else <# ambas as versões têm preRelease #>
    {
        $i = 0
        while($i -lt $preRelease1.Length -and $i -lt $preRelease2.Length -and $preRelease1[$i].Equals($preRelease2[$i]))
        {
            $i++
        }
        if($preRelease1[$i] -gt $preRelease2[$i])
        {
            $version = $input1
        }
        else
        {
            $version = $input2
        }
    }
}

$minor = $version.Split(".")[1]
$patch = $version.Split(".")[2]
$pre = if($version.Length -gt 5) { $version.Split("-")[1] } else { 0 }
if ( $pre -ne 0 -and $pre -ne $null )
{
    $label = "hotfix"
}
elseif ( $patch -ne 0 )
{
    $label = "bug fix"
}
elseif ( $minor -ne 0)
{
    $label = "new feature"
}
else
{
    $label = "breaking change"
}
Write-Output $version", "$label