import shutil

def safecopytree(srcDir, dstDir):
    copy2orig = shutil.copy2

    def safecopy(src, dst):
        try:
            copy2orig(src, dst)
        except Exception as e:
            print e

    shutil.copy2 = safecopy
    shutil.copytree(srcDir, dstDir)
    shutil.copy2 = copy2orig

def main():
    pass