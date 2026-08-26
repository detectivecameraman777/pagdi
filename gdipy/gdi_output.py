#!/usr/bin/env python3


import tkinter as tk
import sys
import time
from random import randint
from math import sin, cos
from ctypes import windll, c_int, c_ulong, byref, create_string_buffer
import win32gui
import win32con
import win32api
import colorsys

class GDIMalware:
    def __init__(self):
        self.root = tk.Tk()
        self.root.title("GDI Effects")
        
        self.root.configure(bg='black')
        

      
        

        # Message box 1
        import ctypes
        result = ctypes.windll.user32.MessageBoxW(0, "Run uffershit.exe?", "Warning", 4)
        if result == 7:  # No button clicked
            self.cleanup()
            return

        # Start the effect sequence
        self.run_effects_sequence()
        
    def cleanup(self):
        """Clean up and exit"""
        self.root.quit()
        self.root.destroy()
        sys.exit(0)
        
    def run_effects_sequence(self):
        """Run effects sequentially with durations"""
        print("")
        
        # Get screen dimensions
        self.screen_width = self.root.winfo_screenwidth()
        self.screen_height = self.root.winfo_screenheight()
        self.hdc = windll.user32.GetDC(0)

        # Phase 1: MultiBlit (Duration: 10.0s)
        print(f"")
        self.run_effect_multiblit()

        # Brief pause between effects
        time.sleep(0.5)

        # Phase 2: Rotate Alpha (Duration: 10.0s)
        print(f"")
        self.run_effect_rotate_alpha()

        # Brief pause between effects
        time.sleep(0.5)

        # Phase 3: PolyBezier (Duration: 10.0s)
        print(f"")
        self.run_effect_polybezier()

        # Brief pause between effects
        time.sleep(0.5)

        # Phase 4: Sine Warp (Duration: 10.0s)
        print(f"")
        self.run_effect_sine_warp()

        # Brief pause between effects
        time.sleep(0.5)

        # Phase 5: Bezier Rainbow (Duration: 10.0s)
        print(f"")
        self.run_effect_bezier_rainbow()

    def run_effect_multiblit(self):
        """Execute MultiBlit effect for 10.0 seconds"""
        print(f"")
        start_time = time.time()
        try:
            # Get screen dimensions
            screen_width = self.root.winfo_screenwidth()
            screen_height = self.root.winfo_screenheight()
            hdc = windll.user32.GetDC(0)
            hdc_mem = windll.gdi32.CreateCompatibleDC(hdc)
            
            # Create compatible bitmap
            hbitmap = windll.gdi32.CreateCompatibleBitmap(hdc, screen_width, screen_height)
            windll.gdi32.SelectObject(hdc_mem, hbitmap)
            
            # Copy screen
            windll.gdi32.BitBlt(hdc_mem, 0, 0, screen_width, screen_height, hdc, 0, 0, 0x00CC0020)
            
            # Effect loop
            iteration = 0
            while time.time() - start_time < 10.0:

                # MultiBlit - multiple copies of screen
                for i in range(0, screen_width, 100):
                    windll.gdi32.BitBlt(hdc, i, iteration % screen_height, 100, 100, hdc_mem, i, 0, 0x00CC0020)
                time.sleep(1/30)
                iteration += 1

            print(f"Completed effect: MultiBlit")
        except Exception as e:
            print(f"Error in MultiBlit: {e}")
        finally:
            windll.gdi32.DeleteObject(hbitmap)
            windll.gdi32.DeleteDC(hdc_mem)
            windll.user32.ReleaseDC(0, hdc)

    def run_effect_rotate_alpha(self):
        """Execute Rotate Alpha effect for 10.0 seconds"""
        print(f"")
        start_time = time.time()
        try:
            # Get screen dimensions
            screen_width = self.root.winfo_screenwidth()
            screen_height = self.root.winfo_screenheight()
            hdc = windll.user32.GetDC(0)
            hdc_mem = windll.gdi32.CreateCompatibleDC(hdc)
            
            # Create compatible bitmap
            hbitmap = windll.gdi32.CreateCompatibleBitmap(hdc, screen_width, screen_height)
            windll.gdi32.SelectObject(hdc_mem, hbitmap)
            
            # Copy screen
            windll.gdi32.BitBlt(hdc_mem, 0, 0, screen_width, screen_height, hdc, 0, 0, 0x00CC0020)
            
            # Effect loop
            iteration = 0
            while time.time() - start_time < 10.0:

                # Rotate + Alpha - screen rotation with transparency
                angle = (iteration % 360) * 3.14159 / 180
                center_x = screen_width // 2
                center_y = screen_height // 2
                for x in range(0, screen_width, 50):
                    for y in range(0, screen_height, 50):
                        dx = x - center_x
                        dy = y - center_y
                        new_x = int(center_x + dx * cos(angle) - dy * sin(angle))
                        new_y = int(center_y + dx * sin(angle) + dy * cos(angle))
                        if 0 <= new_x < screen_width and 0 <= new_y < screen_height:
                            windll.gdi32.BitBlt(hdc, new_x, new_y, 50, 50, hdc_mem, x, y, 0x00CA0080)
                time.sleep(1/30)
                iteration += 1

            print(f"Completed effect: Rotate Alpha")
        except Exception as e:
            print(f"Error in Rotate Alpha: {e}")
        finally:
            windll.gdi32.DeleteObject(hbitmap)
            windll.gdi32.DeleteDC(hdc_mem)
            windll.user32.ReleaseDC(0, hdc)

    def run_effect_polybezier(self):
        """Execute PolyBezier effect for 10.0 seconds"""
        print(f"")
        start_time = time.time()
        try:
            # Get screen dimensions
            screen_width = self.root.winfo_screenwidth()
            screen_height = self.root.winfo_screenheight()
            hdc = windll.user32.GetDC(0)
            hdc_mem = windll.gdi32.CreateCompatibleDC(hdc)
            
            # Create compatible bitmap
            hbitmap = windll.gdi32.CreateCompatibleBitmap(hdc, screen_width, screen_height)
            windll.gdi32.SelectObject(hdc_mem, hbitmap)
            
            # Copy screen
            windll.gdi32.BitBlt(hdc_mem, 0, 0, screen_width, screen_height, hdc, 0, 0, 0x00CC0020)
            
            # Effect loop
            iteration = 0
            while time.time() - start_time < 10.0:

                # PolyBezier - bezier curves with HSV color cycling
                hdc_bezier = win32gui.GetDC(0)
                color_hue = (iteration * 0.02) % 1.0
                rgb = colorsys.hsv_to_rgb(color_hue, 1.0, 1.0)
                p = [(randint(0, screen_width), randint(0, screen_height)) for _ in range(4)]
                pen = win32gui.CreatePen(win32con.PS_SOLID, 5, win32api.RGB(int(rgb[0]*255), int(rgb[1]*255), int(rgb[2]*255)))
                win32gui.SelectObject(hdc_bezier, pen)
                win32gui.PolyBezier(hdc_bezier, p)
                win32gui.DeleteObject(pen)
                win32gui.ReleaseDC(0, hdc_bezier)
                time.sleep(1/30)
                iteration += 1

            print(f"Completed effect: PolyBezier")
        except Exception as e:
            print(f"Error in PolyBezier: {e}")
        finally:
            windll.gdi32.DeleteObject(hbitmap)
            windll.gdi32.DeleteDC(hdc_mem)
            windll.user32.ReleaseDC(0, hdc)

    def run_effect_sine_warp(self):
        """Execute Sine Warp effect for 10.0 seconds"""
        print(f"")
        start_time = time.time()
        try:
            # Get screen dimensions
            screen_width = self.root.winfo_screenwidth()
            screen_height = self.root.winfo_screenheight()
            hdc = windll.user32.GetDC(0)
            hdc_mem = windll.gdi32.CreateCompatibleDC(hdc)
            
            # Create compatible bitmap
            hbitmap = windll.gdi32.CreateCompatibleBitmap(hdc, screen_width, screen_height)
            windll.gdi32.SelectObject(hdc_mem, hbitmap)
            
            # Copy screen
            windll.gdi32.BitBlt(hdc_mem, 0, 0, screen_width, screen_height, hdc, 0, 0, 0x00CC0020)
            
            # Effect loop
            iteration = 0
            while time.time() - start_time < 10.0:

                # Sine Warp - sine wave distortion
                for x in range(0, screen_width, 10):
                    y_offset = int(50 * sin(iteration / 10 + x / 50))
                    windll.gdi32.BitBlt(hdc, x, y_offset, 10, screen_height, hdc_mem, x, 0, 0x00CC0020)
                time.sleep(1/30)
                iteration += 1

            print(f"Completed effect: Sine Warp")
        except Exception as e:
            print(f"Error in Sine Warp: {e}")
        finally:
            windll.gdi32.DeleteObject(hbitmap)
            windll.gdi32.DeleteDC(hdc_mem)
            windll.user32.ReleaseDC(0, hdc)

    def run_effect_bezier_rainbow(self):
        """Execute Bezier Rainbow effect for 10.0 seconds"""
        print(f"")
        start_time = time.time()
        try:
            # Get screen dimensions
            screen_width = self.root.winfo_screenwidth()
            screen_height = self.root.winfo_screenheight()
            hdc = windll.user32.GetDC(0)
            hdc_mem = windll.gdi32.CreateCompatibleDC(hdc)
            
            # Create compatible bitmap
            hbitmap = windll.gdi32.CreateCompatibleBitmap(hdc, screen_width, screen_height)
            windll.gdi32.SelectObject(hdc_mem, hbitmap)
            
            # Copy screen
            windll.gdi32.BitBlt(hdc_mem, 0, 0, screen_width, screen_height, hdc, 0, 0, 0x00CC0020)
            
            # Effect loop
            iteration = 0
            while time.time() - start_time < 10.0:

                # Bezier Rainbow - multiple bezier curves with rainbow colors
                hdc_rainbow = win32gui.GetDC(0)
                for i in range(6):
                    color_hue = ((iteration * 0.02) + (i * 0.1)) % 1.0
                    rgb = colorsys.hsv_to_rgb(color_hue, 1.0, 1.0)
                    p = [(randint(0, screen_width), randint(0, screen_height)) for _ in range(4)]
                    pen = win32gui.CreatePen(win32con.PS_SOLID, 3, win32api.RGB(int(rgb[0]*255), int(rgb[1]*255), int(rgb[2]*255)))
                    win32gui.SelectObject(hdc_rainbow, pen)
                    win32gui.PolyBezier(hdc_rainbow, p)
                    win32gui.DeleteObject(pen)
                win32gui.ReleaseDC(0, hdc_rainbow)
                time.sleep(1/30)
                iteration += 1

            print(f"Completed effect: Bezier Rainbow")
        except Exception as e:
            print(f"Error in Bezier Rainbow: {e}")
        finally:
            windll.gdi32.DeleteObject(hbitmap)
            windll.gdi32.DeleteDC(hdc_mem)
            windll.user32.ReleaseDC(0, hdc)

    def run(self):
        """Start the application"""
        try:
            self.root.mainloop()
        except KeyboardInterrupt:
            self.cleanup()

if __name__ == "__main__":
    try:
        app = GDIMalware()
        app.run()
    except Exception as e:
        print(f"Error: {e}")
        import traceback
        traceback.print_exc()
        input("")
