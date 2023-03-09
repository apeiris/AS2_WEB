# Get the latest tag and extract the build number
$latestTag = git describe --tags --abbrev=0
Write-Output "Latest tag: $latestTag"

$buildNumber = $latestTag.Split('.')[3]
Write-Output "Current build number: $buildNumber"

$major = 1
$minor = 0
$patch = 0

# Increment the build number and update the Git tag
$newBuildNumber = [int]$buildNumber + 1
Write-Output "New build number: $newBuildNumber"

$newTag = "$major.$minor.$patch.$newBuildNumber"
Write-Output "New tag: $newTag"

#git tag -f $newTag
#git push --tags
