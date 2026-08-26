# sounware.py - Bytebeat Player (20 formulas, English interface)
import wave
import winsound
import os
import tempfile
import time
import zipfile
import array
from msvcrt import kbhit, getch

SAMPLE_RATE = 8000

# ========== BYTEBEAT FORMULAS (20) ==========
# 1
def bb1(t):
    if t & 4096:
        return ((t * (t ^ (t % 255)) | (t >> 4)) >> 1) & 255
    else:
        return (t >> 3 | (t << 2 if t & 8192 else t)) & 255

# 2
def bb2(t):
    if t & 2048:
        return (((t ^ (t >> 6)) * (t | 255) >> 3) & 255)
    else:
        return ((t >> 2) ^ (t << 1 if t & 8192 else t >> 1)) & 255

# 3
def bb3(t):
    if t & 1024:
        return ((t * ((t >> 4) & 255) ^ (t >> 7)) & 255)
    else:
        return (((t << 1) | (t >> 5)) & 255)

# 4
def bb4(t):
    if t & 16384:
        return (((t ^ (t >> 8)) * 5) & 255)
    else:
        r = ((t >> 2) ^ (t >> 5))
        if t & 8192:
            r |= 128
        return r & 255

# 5
def bb5(t):
    if t & 4096:
        return ((t * (t ^ (t >> 3)) | (t >> 6)) >> 2) & 255
    else:
        return ((t >> 3) ^ (t << 1 if t & 8192 else t >> 1)) & 255

# 6
def bb6(t):
    if t & 8192:
        return (((t >> 2) ^ (t >> 6)) * 8) & 255
    else:
        if t & 4096:
            return ((t ^ (t >> 5)) * 4) & 255
        else:
            return ((t >> 4) | (t << 1)) & 255

# 7
def bb7(t):
    if t & 2048:
        return ((t * (t >> 5)) & 255)
    else:
        r = ((t >> 2) | (t >> 8))
        if t & 4096:
            r ^= 255
        return r & 255

# 8
def bb8(t):
    if t & 1024:
        return (((t ^ (t >> 4)) * (t >> 3)) & 255)
    else:
        r = ((t >> 1) ^ (t >> 6))
        if t & 512:
            r |= 64
        return r & 255

# 9
def bb9(t):
    if t & 4096:
        return (((t * (t ^ (t >> 2))) >> 4) & 255)
    else:
        return (((t >> 3) + (t >> 7)) & 255)

# 10
def bb10(t):
    if t & 8192:
        return (((t ^ (t >> 7)) * (t & 255) >> 4) & 255)
    else:
        if t & 4096:
            return ((t >> 2) ^ (t >> 5)) & 255
        else:
            return ((t >> 1) | (t << 2)) & 255

# 11
def bb11(t):
    return ((t * (t >> 7)) ^ (t >> 5)) & 255

# 12
def bb12(t):
    return (t | (t >> 6)) * ((t >> 3) & 255) & 255

# 13
def bb13(t):
    return (t * ((t >> 8) & 31) ^ (t >> 4)) & 255

# 14
def bb14(t):
    return ((t >> 5) | (t >> 3)) * (t & 127) & 255

# 15
def bb15(t):
    return ((t ^ (t >> 4)) * (t >> 6) + (t >> 2)) & 255

# 16
def bb16(t):
    return ((t & 65535) * (t >> 9) >> 6) & 255

# 17
def bb17(t):
    return ((t * 3) ^ (t >> 7)) & 255

# 18
def bb18(t):
    return ((t >> 1) | (t >> 3) | (t >> 5)) & 255

# 19
def bb19(t):
    return ((t << 1) ^ (t >> 7) ^ (t >> 4)) & 255

# 20
def bb20(t):
    return ((t * (t >> 9)) ^ (t >> 6)) & 255

functions = [
    bb1, bb2, bb3, bb4, bb5, bb6, bb7, bb8, bb9, bb10,
    bb11, bb12, bb13, bb14, bb15, bb16, bb17, bb18, bb19, bb20
]

names = [
    "Bytebeat #1 (classic pankoza)",
    "Bytebeat #2 (XOR shift variant)",
    "Bytebeat #3 (pure glitch)",
    "Bytebeat #4 (industrial)",
    "Bytebeat #5 (similar to original)",
    "Bytebeat #6 (variable frequency)",
    "Bytebeat #7 (aggressive tremolo)",
    "Bytebeat #8 (modulated noise)",
    "Bytebeat #9 (two-stage chip)",
    "Bytebeat #10 (total chaos)",
    "Bytebeat #11 (slow arpeggio)",
    "Bytebeat #12 (dirty bass)",
    "Bytebeat #13 (digital screech)",
    "Bytebeat #14 (lo-fi pulse)",
    "Bytebeat #15 (FM-like chirp)",
    "Bytebeat #16 (deep rumble)",
    "Bytebeat #17 (simple crunch)",
    "Bytebeat #18 (bit crusher)",
    "Bytebeat #19 (ring mod)",
    "Bytebeat #20 (wobbly drone)"
]

# ========== AUDIO FUNCTIONS ==========
def generate_samples(func, duration):
    num_samples = SAMPLE_RATE * duration
    samples = array.array('b')
    for t in range(num_samples):
        val = func(t) & 0xFF
        samples.append(val - 128)
    return samples.tobytes()

def play_bytebeat(func, duration):
    samples = generate_samples(func, duration)
    with tempfile.NamedTemporaryFile(suffix='.wav', delete=False) as tmp:
        tmp_name = tmp.name
    with wave.open(tmp_name, 'wb') as wf:
        wf.setnchannels(1)
        wf.setsampwidth(1)
        wf.setframerate(SAMPLE_RATE)
        wf.writeframes(samples)
    winsound.PlaySound(tmp_name, winsound.SND_FILENAME | winsound.SND_ASYNC)
    start = time.time()
    while time.time() - start < duration:
        if kbhit() and getch() == b'\x1b':
            winsound.PlaySound(None, winsound.SND_PURGE)
            break
        time.sleep(0.05)
    winsound.PlaySound(None, winsound.SND_PURGE)
    time.sleep(0.1)
    os.remove(tmp_name)

def save_wav(func, duration, filename):
    samples = generate_samples(func, duration)
    with wave.open(filename, 'wb') as wf:
        wf.setnchannels(1)
        wf.setsampwidth(1)
        wf.setframerate(SAMPLE_RATE)
        wf.writeframes(samples)
    print(f"✅ Saved: {filename}")

def create_zip_with_all():
    temp_dir = "temp_bytebeat"
    os.makedirs(temp_dir, exist_ok=True)
    files = []
    for i, func in enumerate(functions, 1):
        fname = os.path.join(temp_dir, f"bytebeat_{i:02d}.wav")
        save_wav(func, 10, fname)
        files.append(fname)
    zip_name = "bytebeat_sounds.zip"
    with zipfile.ZipFile(zip_name, 'w') as zf:
        for f in files:
            zf.write(f, os.path.basename(f))
    print(f"✅ ZIP created: {zip_name}")
    for f in files:
        os.remove(f)
    os.rmdir(temp_dir)
    os.system("start .")

def clear_screen():
    os.system('cls' if os.name == 'nt' else 'clear')

# ========== MAIN MENU ==========
def main():
    clear_screen()
    print("╔══════════════════════════════════════════════════════════════╗")
    print("║                🎵 SOUNWARE - BY LOU 🎵                        ║")
    print("╠══════════════════════════════════════════════════════════════╣")
    print("║  This program is a cool tool to create GDI malwares, use    ║")
    print("║  it with Malmenu, i'll soon create a tool to generate exes. ║")
    print("║  This is a harmless tool.                                   ║")
    print("║  Press ESC to stop the sound.                               ║")
    print("╚══════════════════════════════════════════════════════════════╝\n")

    while True:
        print("╔══════════════════════════════════════════════════════════════╗")
        for i, name in enumerate(names, 1):
            print(f"║  [{i:2d}]  {name:<50} ║")
        print("╠══════════════════════════════════════════════════════════════╣")
        print("║  [99] Play ALL bytebeats (10 sec each)                       ║")
        print("║  [98] Download ALL as WAV (ZIP)                              ║")
        print("║  [97] Download a specific bytebeat (WAV)                     ║")
        print("║  [0]  Exit                                                   ║")
        print("╚══════════════════════════════════════════════════════════════╝")
        opt = input("\n> Choose an option: ").strip()

        if opt == '0':
            break
        elif opt.isdigit() and 1 <= int(opt) <= len(functions):
            idx = int(opt) - 1
            print(f"\n🔊 Playing {names[idx]} for 10 seconds... (press ESC to stop)")
            play_bytebeat(functions[idx], 10)
            print("✅ Playback finished.\n")
        elif opt == '99':
            print("\n🎶 Playing all bytebeats (10 sec each). Press ESC to cancel.\n")
            for i, func in enumerate(functions):
                print(f"Playing {names[i]}...")
                play_bytebeat(func, 10)
                if kbhit() and getch() == b'\x1b':
                    break
            print("✅ Sequence finished.\n")
        elif opt == '98':
            print("\n📦 Generating WAV files and ZIP...")
            create_zip_with_all()
            print()
        elif opt == '97':
            print(f"\n📥 Which bytebeat? (1 to {len(functions)}): ", end='')
            num = input().strip()
            if num.isdigit() and 1 <= int(num) <= len(functions):
                idx = int(num) - 1
                fname = f"bytebeat_{int(num):02d}.wav"
                print(f"Generating {fname}...")
                save_wav(functions[idx], 10, fname)
            else:
                print("❌ Invalid number.\n")
        else:
            print("❌ Invalid option.\n")

        input("Press Enter to continue...")
        clear_screen()

    print("\n👋 Thanks for using SOUNWARE!")

if __name__ == "__main__":
    main()